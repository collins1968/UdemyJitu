﻿namespace UdemyJitu.Responses
{
    public class CourseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public Guid InstructorId { get; set; }
    }
}
