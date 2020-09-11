using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WpfProjectIdeas.Classes
{
    public class SQLiteAction
    {
        public static void SaveNewToDB(ProjectIdea projectIdea)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<ProjectIdea>();
                conn.Insert(projectIdea);
                //MessageBox.Show("New project idea successfully inserted");
            }
        }

        public static void UpdateToDB(ProjectIdea projectIdea)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<ProjectIdea>();
                conn.Update(projectIdea);
                //MessageBox.Show("Project idea was successfully updated");
            }
        }

        public static void DeleteFromDB(ProjectIdea projectIdea)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<ProjectIdea>();
                conn.Delete(projectIdea);
            }
        }

        public static void BackupDB()
        {
            
        }
    }
}
