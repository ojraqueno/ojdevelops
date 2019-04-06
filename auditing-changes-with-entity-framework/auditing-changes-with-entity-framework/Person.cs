using System;
using System.ComponentModel.DataAnnotations;

namespace auditing_changes_with_entity_framework
{
    [TrackChanges]
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}