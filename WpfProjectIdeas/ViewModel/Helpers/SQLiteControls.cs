using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WpfProjectIdeas.Model;

namespace WpfProjectIdeas.ViewModel.Helpers
{
    public class SQLiteControls
    {
        static string databaseName = "ProjectIdeasDB.db";
        public static string folderPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
 
        public static void SaveNewToDB(ProjectIdea projectIdea)
        {
            using (SQLiteConnection conn = new SQLiteConnection(databasePath))
            {
                conn.CreateTable<ProjectIdea>();
                conn.Insert(projectIdea);
                //MessageBox.Show("New project idea successfully inserted");
            }
        }

        public static void UpdateToDB(ProjectIdea projectIdea)
        {
            using (SQLiteConnection conn = new SQLiteConnection(databasePath))
            {
                conn.CreateTable<ProjectIdea>();
                conn.Update(projectIdea);
                //MessageBox.Show("Project idea was successfully updated");
            }
        }

        public static void DeleteFromDB(ProjectIdea projectIdea)
        {
            using(SQLiteConnection conn = new SQLiteConnection(databasePath))
            {
                conn.CreateTable<ProjectIdea>();
                conn.Delete(projectIdea);
            }
        }

        public static List<ProjectIdea> GetProjectIdeas()
        {
            var projectIdeas = new List<ProjectIdea>();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(databasePath))
            {
                conn.CreateTable<ProjectIdea>();
                projectIdeas = conn.Table<ProjectIdea>().OrderBy(projectIdea => projectIdea.Name).ToList();
            }

            return projectIdeas;
        }

        public static void BackupDB()
        {
            
        }
    }
}
