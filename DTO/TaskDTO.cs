﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class TaskDTO
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsImportant { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }

        public TaskDTO() { }

        public TaskDTO(int taskID, string title, string description, string dueDate, DateTime createdDate, bool isImportant, bool isCompleted, bool isDeleted, string createdBy)
        {
            TaskID = taskID;
            Title = title;
            Description = description;
            DueDate = dueDate;
            CreatedDate = createdDate;
            IsImportant = isImportant;
            IsCompleted = isCompleted;
            IsDeleted = isDeleted;
            CreatedBy = createdBy;
        }

        public override string ToString()
        {
            return $"TaskDTO [TaskID={TaskID}, Title={Title}, Description={Description}, DueDate={DueDate}, CreatedDate={CreatedDate}, " +
                   $"IsImportant={IsImportant}, IsCompleted={IsCompleted}, IsDeleted={IsDeleted}, CreatedBy={CreatedBy}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (TaskDTO)obj;
            return TaskID == other.TaskID &&
                   Title == other.Title &&
                   Description == other.Description &&
                   DueDate == other.DueDate &&
                   CreatedDate == other.CreatedDate &&
                   IsImportant == other.IsImportant &&
                   IsCompleted == other.IsCompleted &&
                   IsDeleted == other.IsDeleted &&
                   CreatedBy == other.CreatedBy;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + TaskID.GetHashCode();
            hash = hash * 31 + (Title != null ? Title.GetHashCode() : 0);
            hash = hash * 31 + (Description != null ? Description.GetHashCode() : 0);
            hash = hash * 31 + (DueDate != null ? DueDate.GetHashCode() : 0);
            hash = hash * 31 + CreatedDate.GetHashCode();
            hash = hash * 31 + IsImportant.GetHashCode();
            hash = hash * 31 + IsCompleted.GetHashCode();
            hash = hash * 31 + IsDeleted.GetHashCode();
            hash = hash * 31 + (CreatedBy != null ? CreatedBy.GetHashCode() : 0);
            return hash;
        }

    }
}