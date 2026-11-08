using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace MyBaseOnCSharp
{
    internal class DB_MyBase
    {
        private string connectionString = "server=localhost;port=3306;user=root;password=password";//строка подключения к базе
        private MySqlConnection conn;
        public DB_MyBase()
        {
            conn = new MySqlConnection(connectionString);
        }

        public void Add_Node_in_Base(string number,string type, string title, int level, string parent_num)
        { 
            MySqlCommand cmd = new MySqlCommand("", conn);

            //добавление записи 
            if (parent_num != null)
            {
                cmd.CommandText = @"USE myBase;
                               INSERT INTO objects(number, type,title,level, parent_num)
                               VALUES (@number,@type,@title,@level, @parent_num); ";
            }
            else
            {
                cmd.CommandText = @"USE myBase;
                               INSERT INTO objects(number, type,title,level)
                               VALUES (@number,@type,@title,@level); ";
            }
            cmd.Parameters.AddWithValue("@number", number);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@level", level);
            if (parent_num != null)
            {
                cmd.Parameters.AddWithValue("@parent_num", parent_num);
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        private void SearchChildsNode(TreeNode Parent, List<string> nums)
        {
            foreach (TreeNode child in Parent.Nodes)
            {
                nums.Add(child.Name);
                SearchChildsNode(child, nums);
            }
        }
        public void Delete_Node_From_Base(TreeNode nodeDelete)
        { 
            List<string>numsNodeDelete = new List<string>();
            SearchChildsNode(nodeDelete, numsNodeDelete);
            numsNodeDelete.Add(nodeDelete.Name);//добавили удаляемый узел
            //запрос на поиск id по номеру
            string SearchId = @"USE myBase;
                                SELECT id
                                FROM objects
                                WHERE number=@num;";
            string DeleteRecord = @"USE myBase;
                                    DELETE FROM objects
                                    WHERE id=@id;";
            //удаляем записи из бд
            MySqlCommand cmd = new MySqlCommand("", conn);
            conn.Open();
            for (int i = 0; i < numsNodeDelete.Count(); i++)
            { 
                string num=numsNodeDelete[i];
                cmd.CommandText = SearchId;
                cmd.Parameters.AddWithValue("@num", num);
                string id = Convert.ToString(cmd.ExecuteScalar());
                cmd.CommandText= DeleteRecord;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            conn.Close();
        }
        private void SearchNodeForSearchParent(TreeNode node, string parent_num, ref TreeNode ParentNode)
        {
            if (node.Name == parent_num)
            {
                ParentNode=node;
                return;
            }
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                SearchNodeForSearchParent(node.Nodes[i], parent_num, ref ParentNode);
            }
        }
        private TreeNode SearchParent(TreeView tree,string parent_num)
        {
            TreeNode result = null;
            foreach (TreeNode node in tree.Nodes)
            {
                SearchNodeForSearchParent(node, parent_num, ref result);
                if (result != null)
                { 
                    return result;
                }
            }
            return null;
        }
        public void UnLoadNodeInTree(TreeView tree, Dictionary<string,int> indexIconforNode)
        {
            //идея такая, сначала смотрим сколько всего записей и затем поуровнего добавляем записи, т.е. сначала все корневые и т.д.
            // 1. смотрим сколько всего записей в базе
            MySqlCommand cmd = new MySqlCommand("", conn);
            cmd.CommandText = @"USE myBase;
                                SELECT COUNT(id)
                                FROM objects;";
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            //2. достаем элементы из базы, пока не достанем все
            int level = 0;
            while (count != 0)
            {
                //достаем все узлы i-уровня
                List<List<string>> nodes = new List<List<string>>();
                cmd.Parameters.Clear();
                cmd.CommandText = @"USE myBase;
                                    SELECT 
                                        number,
                                        type,
                                        title,
                                        parent_num
                                    FROM objects
                                    WHERE level=@level;";
                cmd.Parameters.AddWithValue("@level", level);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                { 
                    nodes.Add(new List<string>() { Convert.ToString(reader["number"]), Convert.ToString(reader["type"]), Convert.ToString(reader["title"]), Convert.ToString(reader["parent_num"]) });
                }
                //если parent_num в базе null, то сюда записывается пустая строка ""
                reader.Close();
                
                //добавляем узлы в дерево
                for (int i = 0; i < nodes.Count; i++)
                {
                    TreeNode node = new TreeNode() { Name = nodes[i][0], Tag = nodes[i][1], Text = nodes[i][2], ImageIndex = indexIconforNode[nodes[i][1]], SelectedImageIndex = indexIconforNode[nodes[i][1]] };
                    string parent_num = nodes[i][3];
                    if (parent_num == "")//это корневой узел
                    {
                        tree.Nodes.Add(node);
                    }
                    else 
                    {
                        // поиск родителя на предыдущем уровне
                        TreeNode Parent = SearchParent(tree, parent_num);
                        Parent.Nodes.Add(node);
                    }
                }
                level++;
                count-=nodes.Count;
            }
            conn.Close();
        }
        //функция нужна, когда перетаскиваем узел на другой уровень или другому родителю
        public void EditPositionNode(string numNode, string numNewParent, int newLevel)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("", conn);
            cmd.CommandText = @"USE myBase;
                              UPDATE objects
                              SET level=@newLevel,parent_num=@numNewParent
                              WHERE number=@numNode;";
            cmd.Parameters.AddWithValue("@newLevel", newLevel);
            if (numNewParent != null)
            {
                cmd.Parameters.AddWithValue("@numNewParent", numNewParent);
            }
            else
            {
                cmd.Parameters.AddWithValue("@numNewParent", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@numNode", numNode);
            cmd.ExecuteNonQuery();
            conn.Close();   
        }

        public void Add_Record_In_Node(string numberNode, string data)
        {
            MySqlCommand cmd = new MySqlCommand("", conn);
            cmd.CommandText = @"USE myBase;
                                UPDATE objects
                                SET data=@data
                                WHERE number=@numberNode;";
            cmd.Parameters.AddWithValue("@numberNode", numberNode);
            cmd.Parameters.AddWithValue("@data", data);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public string GetDataFromNode(string numberNode)
        {
            MySqlCommand cmd = new MySqlCommand("", conn);
            cmd.CommandText = @"USE myBase;
                                SELECT data
                                FROM objects
                                WHERE number=@numberNode;";
            cmd.Parameters.AddWithValue("@numberNode", numberNode);
            conn.Open();
            string data=Convert.ToString(cmd.ExecuteScalar());  
            conn.Close();
            return data;
        }
        public void ClearRecord(string numberNode)
        {
            MySqlCommand cmd = new MySqlCommand("", conn);
            cmd.CommandText = @"USE myBase;
                                UPDATE objects
                                SET data=@data
                                WHERE number=@numberNode;";
            cmd.Parameters.AddWithValue("@numberNode", numberNode);
            cmd.Parameters.AddWithValue("@data", "");
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<KeyValuePair<string, string>> SearchRecord(string nameRecord, string textRecord, string addressWebSite)
        { 
            string SearchQuery = @"USE myBase;
                                 SELECT 
                                    number,
                                    title,
                                    data,
                                    type
                                 FROM objects ";
            MySqlCommand cmd=new MySqlCommand("", conn);
            //фильтрация по имени
            if (nameRecord != null)
            {
                SearchQuery += "WHERE INSTR(title,@nameRecord)>0;";
                cmd.Parameters.AddWithValue("@nameRecord", nameRecord);
            }
            else
            {
                SearchQuery += ";";
            }
            cmd.CommandText= SearchQuery;
            List<List<string>> buffer = new List<List<string>>();//найденные узлов
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buffer.Add(new List<string> { reader["number"].ToString(), reader["title"].ToString(), Convert.ToString(reader["data"]), reader["type"].ToString() });
            }
            conn.Close();
            //теперь надо провести фильтрацию по тексту и гиперссылкам
            List<KeyValuePair<string,string>>result= new List<KeyValuePair<string,string>>();//number-title
            RichTextBox tmp= new RichTextBox();
            foreach (List<string> record in buffer)
            {
                tmp.Rtf = record[2];
                //фильрация
                if (textRecord != null && addressWebSite != null)//поиск по обоим полям
                {
                    if (tmp.Text.ToLower().Contains(textRecord.ToLower()) && tmp.Text.ToLower().Contains(addressWebSite.ToLower()))
                    {
                        string type_node = "";
                        if (record[3] == "folder")
                        {
                            type_node = "Папка: ";
                        }
                        else if (record[3] == "file")
                        {
                            type_node = "Файл: ";
                        }
                        else
                        {
                            type_node = "Заметка: ";
                        }
                        result.Add(new KeyValuePair<string, string>(record[0], type_node+record[1]));
                    }
                }
                else if (textRecord != null)
                {
                    if (tmp.Text.ToLower().Contains(textRecord.ToLower()))//если подстрока встречается, то запись подходит
                    {
                        string type_node = "";
                        if (record[3] == "folder")
                        {
                            type_node = "Папка: ";
                        }
                        else if (record[3] == "file")
                        {
                            type_node = "Файл: ";
                        }
                        else
                        {
                            type_node = "Заметка: ";
                        }
                        result.Add(new KeyValuePair<string, string>(record[0], type_node + record[1]));
                    }
                }
                else if (addressWebSite != null)
                {
                    if (tmp.Text.ToLower().Contains(addressWebSite.ToLower()))//если подстрока встречается, то запись подходит
                    {
                        string type_node = "";
                        if (record[3] == "folder")
                        {
                            type_node = "Папка: ";
                        }
                        else if (record[3] == "file")
                        {
                            type_node = "Файл: ";
                        }
                        else
                        {
                            type_node = "Заметка: ";
                        }
                        result.Add(new KeyValuePair<string, string>(record[0], type_node + record[1]));
                    }
                }
                else //если оба поля null
                {
                    string type_node = "";
                    if (record[3] == "folder")
                    {
                        type_node = "Папка: ";
                    }
                    else if (record[3] == "file")
                    {
                        type_node = "Файл: ";
                    }
                    else
                    {
                        type_node = "Заметка: ";
                    }
                    result.Add(new KeyValuePair<string, string>(record[0], type_node + record[1]));
                }

            }
            return result;
        }
    }
}
