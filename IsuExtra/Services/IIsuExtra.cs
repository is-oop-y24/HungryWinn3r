﻿using System;
using System.Collections.Generic;
using Isu;

namespace IsuExtra.Services
{
    public interface IIsuExtra
    {
        Lesson AddLesson(int date, DateTime time, string teacher, int classroom, Group ognpGroup);
        Lesson AddLesson(int date, DateTime time, string teacher, int classroom);
        Ognp AddOgnp(string name, string faculty);
        Stream AddStream(string name, int limit);
        void AddStudentToLessons(Student student, List<Lesson> lessons);
        void AddStudentToOgnp(Ognp ognp, Stream stream, Student student);
        void RemoveStudentFromOgnp(Stream stream, Student student);
        List<Stream> FindStreams(CourseNumber courseNumber);
        List<Student> FindStudents(string groupName);
        List<Student> FindStudentsWithoutOgnp();
        void AddStreamToOgnp(Ognp ognp, Stream stream);
    }
}
