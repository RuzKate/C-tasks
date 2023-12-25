using System;

namespace delegate2
{
    class Program
    {
        public class Task
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public bool IsCompleted { get; set; }
        }

        public class TaskManager
        {
            public delegate void TaskCompletedEventHandler(Task task); // при помощи делегата мы оповещаем, что задача была завершена

            public event TaskCompletedEventHandler TaskCompleted;

            public void CompleteTask(Task task)
            {
                task.IsCompleted = true;
                OnTaskCompleted(task);
            }

            protected virtual void OnTaskCompleted(Task task)
            {
                TaskCompleted?.Invoke(task); // вызываем делегат только в том случае, если он не равен null. И выполняет все методы, которые есть у детелегата TaskCompletedEventHandler
            }
        }

        public class NotificationService // оповещение пользоватлеей о событиях

        {
            public void TaskCompletedNotification(Task task)
            {
                Console.WriteLine($"Задача \"{task.Title}\" выполнена.");
            }
        }


        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            NotificationService notificationService = new NotificationService();

            taskManager.TaskCompleted += notificationService.TaskCompletedNotification; // добавялем метод TaskCompletedNotification в список методов, которые вызываюся при создании объекта TaskCompleted

            Task task1 = new Task { Title = "Задча 1", Description = "Описание задачи 1" };
            Task task2 = new Task { Title = "Задача 2", Description = "Описание задачи 2" };
            Task task3 = new Task { Title = "Задача 3", Description = "Описание задачи 3" };
            Task task4 = new Task { Title = "Задача 4", Description = "Описание задачи 4" };
            Task task5 = new Task { Title = "Задача 5", Description = "Описание задачи 5" };
            Task task6 = new Task { Title = "Задача 6", Description = "Описание задачи 6" };
            Task task7 = new Task { Title = "Задача 7", Description = "Описание задачи 7" };

            taskManager.CompleteTask(task1);
            taskManager.CompleteTask(task3);
            taskManager.CompleteTask(task7);
            taskManager.CompleteTask(task2);
        }
    }
}
