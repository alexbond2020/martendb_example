using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public TodoItem()
        {

        }

        public TodoItem(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}