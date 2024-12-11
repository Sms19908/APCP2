using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APCP2.Data;
using APCP2.Repositories;

namespace APCP2.Services
{
    internal interface IServicesBase { 
            IEnumerable<TaskManager> GetAllTasks();
            TaskManager GetTasksById(int id);
            void CreateTasks(TaskManager tasks);
            void UpdateTasks(TaskManager tasks);
            void DeleteTasks(int id);
    }

    public class TaskService : IServicesBase
    {
        private readonly RepositoryTask<TaskManager> repositoryTasks;

        public TaskService(RepositoryTask<TaskManager> repository)
        {
            repositoryTasks = repository;
        }

        public IEnumerable<TaskManager> GetAllTasks()
        {
            return repositoryTasks.GetAll();
        }

        public TaskManager GetTasksById(int id)
        {
            return repositoryTasks.Get(id);
        }

        public void CreateTasks(TaskManager tasks)
        {
            repositoryTasks.Insert(tasks);
            repositoryTasks.Save();
        }

        public void UpdateTasks(TaskManager tasks)
        {
            repositoryTasks.Update(tasks);
            repositoryTasks.Save();
        }

        public void DeleteTasks(int id)
        {
            repositoryTasks.Delete(id);
            repositoryTasks.Save();
        }
    }
}
