using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tips.Domain.Entities
{
    public class Tip : BaseViewModel
    {
        private int tipId;
        private DateTime creationDate;
        private DateTime updateDate;
        private string title;
        private string description;

        [PrimaryKey, AutoIncrement]
        public int TipId
        {
            get => tipId;
            set=> SetValue(ref tipId, value);
        }
        public DateTime CreationDate
        {
            get=> creationDate;
            set=> SetValue(ref creationDate, value);
        }
        public string Title
        {
            get=> title;
            set=> SetValue(ref title, value);
        }
        public string Description
        {
            get=> description;
            set=> SetValue(ref description,value);
        }
        public DateTime UpdateDate
        {
            get=> updateDate;
            set=> SetValue(ref updateDate,value); 
        }
    }
}
