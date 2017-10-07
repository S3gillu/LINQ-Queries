using System;
using System.Collections.Generic;
using System.Linq;
namespace LINQ
{     
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }    
        public int StandardID { get; set; }
    }

    public class Standard
    {

        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() {StudentID = 1, StudentName = "Shubham", Age = 18, StandardID = 1},
                new Student() {StudentID = 2, StudentName = "Saurabh", Age = 19, StandardID = 2},
                new Student() {StudentID = 3, StudentName = "Mayank", Age = 21, StandardID = 2},
                new Student() {StudentID = 4, StudentName = "manisha", Age = 18, StandardID = 1},
                new Student() {StudentID = 5, StudentName = "Manshu", Age = 21 }
            };

            IList<Standard> standardList = new List<Standard>()
            {
                new Standard() {StandardID = 1 , StandardName = "Standard-1" },
                new Standard() {StandardID = 2, StandardName = "Standard-2"},
                new Standard() {StandardID = 3, StandardName = "Standard-3"}
            };


            /// This code is for where operator using Method Syntax. It filters the collections based on Predicate Function.

            var resultwhere = studentList.Where(s => s.Age > 12 && s.Age < 20);

            foreach (var i in resultwhere)
            {
                Console.WriteLine("Student Name : {0}, Age {1}", i.StudentName, i.Age);
            }


            // This code is for OfType operator using Method Syntax. It filters the collection based on a given type.


            var rsultOfType = studentList.OfType<string>();


            // This code is for OrderBy operator. By default it is ascending in nature. This is a sorting operator.

            Console.WriteLine();

            Console.WriteLine("Order By Ascending");

            var orderByResult = studentList.OrderBy(s => s.StudentName);

            foreach (var i in orderByResult)
            {
                Console.WriteLine(i.StudentName);
            }

            // This code is for OrderByDecsending.This is a sorting operator.

            Console.WriteLine();

            Console.WriteLine("Order by Descending");

            var orderByDescendingResult = studentList.OrderByDescending(s => s.StudentName);

            foreach (var i in orderByDescendingResult)
            {
                Console.WriteLine(i.StudentName);
            }

            //This code is for ThenBy operator. This is a sorting operator. Used Only with method syntax. It is used after OrderBy operator to set another field 
            // in Ascending order. It only sets another field in ascending or descending order when it gets a common record (say name).

            Console.WriteLine();

            var thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(p => p.Age);

            foreach (var i in studentList)
            {
                Console.WriteLine("Student Name {0}, Age {1}", i.StudentName, i.Age);
            }

            // This code is for ThenByDescending operator. This is also a sorting operator. Used only with method syntax. It is used after OrderBy operator to set
            // another field in Descending order.

            Console.WriteLine();

            var ThenByDescendingResult = studentList.OrderByDescending(s => s.StudentName).ThenByDescending(s => s.Age);
            foreach (var i in ThenByDescendingResult)
            {
                Console.WriteLine("Student Name: {0}, Age: {1}", i.StudentName,i.Age);
            }


            //This code is for GroupBy operators. This is also a sorting operator.

            Console.WriteLine();

            var groupByOpertorResult = studentList.GroupBy(s => s.Age);
            
            foreach(var s in groupByOpertorResult)
            {
                Console.WriteLine("Age Group:{0}",s.Key);
                foreach(var i in s)
                    Console.WriteLine("Student Name :{0}", i.StudentName);

            }

            //This code is for ToLookup operator. This is also a sorting operator . It executes the code immediately whereas GroupBy executes codes deffered.

            Console.WriteLine();

            var toLookUpresult = studentList.ToLookup(s => s.Age);
            foreach(var s in toLookUpresult)
            {
                Console.WriteLine("Age Group:{0}", s.Key);
                foreach(var i in s)
                {
                    Console.WriteLine( "Student Name : {0}", i.StudentName);
                }
            }

            //This code is for Join opertaor. It joins two sequences based on a key and returns resulted sequences.

            Console.WriteLine();

            var innerjoin = studentList.Join(standardList,
                                              student => student.StandardID,
                                              standard => standard.StandardID,
                                              (student, standard) => new
                                              {
                                                  StudentName = student.StudentName,
                                                  StandardName = standard.StandardName
                                              });
            
            foreach(var i in innerjoin)
            {
                Console.WriteLine("{0} - {1}", i.StudentName,i.StandardName);
            }


            // This code is for Group Join. It results the result in group based on a specified group key.

            Console.WriteLine();
            var groupjoin = standardList.GroupJoin(studentList,
                                                    std => std.StandardID,
                                                     s => s.StandardID,
                                                     (std, StandardGroup) => new
                                                     {
                                                         students = StandardGroup,
                                                         std = std.StandardName
                                                     });
            foreach(var i in groupjoin)
            {
                Console.WriteLine("Standard Name {0}", i.std);

                foreach(var s in i.students)
                    Console.WriteLine( "Student Name : {0}", s.StudentName);
            }

            // This code is for Projection  Operator (Select , SelectMany).

            Console.WriteLine();

            var selectResult = studentList.Select(s => new { Name = s.StudentName, Age = s.Age });

            foreach( var i in selectResult)
            {
                Console.WriteLine("Name {0}, Age {1}",i.Name,i.Age);
            }



            // This code is for Quantifier Operators ( All , Any, Contain). This is will return a boolean value to indicate that some or all elements 
            //satisfy the condition. For these opearators we don't need any foreach loop. These are not supported in Query syntax.

            Console.WriteLine();

            bool allStudentsAreTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine(allStudentsAreTeenAger);

            bool isAnyStudentteenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine(isAnyStudentteenAger);


            IList<int> intList = new List<int>() { 1, 2, 3 };

            bool containResult = intList.Contains(8);

            Console.WriteLine(containResult);

            // This code is for Aggregation Operators (Aggregate, Average, Count, LongCount, Max, Min, Sum). 

            Console.WriteLine();


            IList<String> String = new List<String>() { "One", "Two", "Three" };

            var aggregateResult = String.Aggregate((s1, s2) => s1 + " , " + s2);

            Console.WriteLine(aggregateResult);


            Console.WriteLine();

            IList<int> IntList = new List<int>() { 10, 20, 30 };

            var averageResult = IntList.Average();

            Console.WriteLine(averageResult);


            Console.WriteLine();

            var numberOfStudents = studentList.Count();
            Console.WriteLine(numberOfStudents);

            Console.WriteLine();

            var maxResult = IntList.Max();
            Console.WriteLine(maxResult);

            Console.WriteLine();

            var minResult = IntList.Min();
            Console.WriteLine(minResult);

            Console.WriteLine();

            var sumResult = IntList.Sum();
            Console.WriteLine(sumResult);

            Console.WriteLine();

            // This code is for Element Operators (ElementAt , ElementAtOrDefault). 
            // "ElementAt" returns the element at a specified index in the collection.
            // "ElementAtOrdefault"  returns the element at a specified index in the collection or a default value if the index is out of range.
            // foreach loop is again not required in these operators.

            Console.WriteLine(" First Element at the index : {0}", String.ElementAt(0));

            // Console.WriteLine("Fourth Element at the index : {4}", String.ElementAtOrDefault(4));

            Console.WriteLine();

            // This code is for Element Operators ( First , FirstOrDefault).
            // "First" returns the first element of a collection , or the first element that satisfies the condition.
            // "FirstorDefault" returns the first element of a collection , or the first element that satisfies the condition. Return a default value if index is out of range.

            var firstResult = String.First();
            Console.WriteLine(firstResult);

            Console.WriteLine();

            var fisrtOrdefaultResult = String.FirstOrDefault();
            Console.WriteLine(fisrtOrdefaultResult);

            Console.WriteLine();

            // This code is for Element Operators ( Last , LastOrDefault).
            // "Last" returns the last element of a collection , or the last element that satisfies the condition.
            // "LastOrDefault" returns the last element of a collection , or the last element that satisfies the condition. Return a default value if index is out of range.

            var lastresult = String.Last();
            Console.WriteLine(lastresult);

            Console.WriteLine();

            var lastOrDefault = String.LastOrDefault();
            Console.WriteLine(lastOrDefault);

            Console.WriteLine();

            // This code is for Element Operators (Single , SingleOrDefault).
            // "Single" returns the only element from a collection, or the only element that satisfies a condition.
            // If Single() found no elements or more than one elements in the collection then throws InvalidOperationException.
            // "SingleOrDefault" The same as Single, except that it returns a default value of a specified generic type, instead of throwing an exception 
            // if no element found for the specified condition. 
            // However, it will thrown InvalidOperationException if it found more than one element for the specified condition in the collection.

            /* var singleResult = String.Single();
             Console.WriteLine(singleResult); 

             var singleOrDefault = String.SingleOrDefault();
             Console.WriteLine(singleOrDefault); */


            Console.WriteLine();

            // This code is for Equality operator (SequenceEqual). foreach loop is not required for this operator.

            IList<String> StrList1 = new List<String>() { "One", "Two", "Three" };
            IList<String> StrList2 = new List<String>() { "One", "Two", "Three" };
            IList<String> StrList3 = new List<String>() { "Five", "Six" };

            var resultSequence = StrList1.SequenceEqual(StrList2);
            Console.WriteLine(resultSequence);

            Console.WriteLine();

            // This code is for Concatenation Operator (Concat). The Concat() method appends two sequences of the same type and returns a new sequence (collection).
            // This operator requires a foreach loop.

            var concatResult = StrList1.Concat(StrList3);

            foreach(var i in concatResult)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(concatResult);

            Console.WriteLine();

            // This code is for Generation Operator (DafaultIfEmpty). This method returns a new collection with the default value if the given collection on which
            //  DefaultIfEmpty() is invoked is empty.
            // foreach loop is not required.

            IList<int> emptyList = new List<int>();

            var newList1 = emptyList.DefaultIfEmpty();
            Console.WriteLine("Count :{0}",newList1.Count());
            Console.WriteLine("Value :{0}", newList1.ElementAt(0));

            var newList2 = emptyList.DefaultIfEmpty(100);
            Console.WriteLine("Count :{0}", newList2.Count());
            Console.WriteLine("Value :{0}", newList2.ElementAt(0));

            Console.WriteLine();

            // This code is again for Generation operators (Empty, Range, Repeat).
            // Empty returns an empty collection. It is a static methos (Included in Enumerable Static Class)not an extension method.
            //foreach is not required for this operator.
           
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<Student>();

            Console.WriteLine("Type: {0}", emptyCollection1.GetType().Name);
            Console.WriteLine("Count: {0}", emptyCollection1.Count());

            Console.WriteLine("Type: {0}", emptyCollection2.GetType().Name);
            Console.WriteLine("Count: {0}", emptyCollection2.Count());

            Console.WriteLine();

            // Range --> Generates collection of IEnumerable<T> type with specified number of elements with sequential values, starting from first element.

            var intcollection = Enumerable.Range(10, 10);
            Console.WriteLine("Total Count : {0}", intcollection.Count());

            for (int i = 0; i < intcollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intcollection.ElementAt(i));

            // Repeat --> Generates a collection of IEnumerable<T> type with specified number of elements and each element contains same specified value.

            Console.WriteLine();

            var intCollection = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));

            Console.WriteLine();

            // This code is for Set Operator (Distinct , Except, Intersect, Union).

            //Distinct --> Returns Distinct value from a collection.

            IList<int> newList = new List<int>() { 10, 20, 30, 40, 50 };
            IList<int> newList101 = new List<int>() { 20, 40, 60, 80, 100 };

            var result1 = newList.Distinct();
            foreach (var i in result1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // Except --> Returns the difference between two sequences, which means the elements of one collection that do not appear in the second collection.
            Console.WriteLine();

            var result2 = newList.Except(newList101);
            foreach(var i in result2)
            {
                Console.WriteLine(i);
            }



            // Intersect --> Returns the intersection of two sequences, which means elements that appear in both the collections.

            Console.WriteLine();

            var result3 = newList.Intersect(newList101);
            foreach(var i in result3)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            // Union --> 	Returns unique elements from two sequences, which means unique elements that appear in either of the two sequences.

            var result4 = newList.Union(newList101);
            foreach(var i in result4)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            // This code is for Partitioning Operators ( Skip & SkipWhile , Take & TakeWhile).

            // Skip --> Skips elements up to a specified position starting from the first element in a sequence.

            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var result5 = strList.Skip(2);
            foreach(var i in result5)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // SkipWhile --> Skips elements based on a condition until an element does not satisfy the condition. 
            //If the first element itself doesn't satisfy the condition, it then skips 0 elements and returns all the elements in the sequence.

            var result6 = strList.SkipWhile(s => s.Length < 4);
            foreach(var i in result6)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            // Take --> Takes elements up to a specified position starting from the first element in a sequence.

            var result7 = strList.Take(2);
            foreach(var i in result7)
            {
                Console.WriteLine(i);
            }

           

            //TakeWhile --> Returns elements from the given collection until the specified condition is true. 
            //If the first element itself doesn't satisfy the condition then returns an empty collection.

            var result8 = strList.TakeWhile(s => s.Length > 4);
            foreach (var i in result8)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            //This is code is for Conversion Operators (AS , To, Casting)
            // As (As Enumerable , As Queryable)
            // To ( ToArray , ToList , ToLookUp , ToDictionary) --? source object is converted into these types.
            // Casting (Cast , OfType) --> cast changes the source object into IEnumerable<T>.


            var intoresult = studentList.Where(s => s.Age > 12 && s.Age < 20 && s.StudentName.StartsWith("S"));
            foreach(var i in intoresult)
            {
                Console.WriteLine(i.StudentName);
            }
           

            Console.WriteLine();

            var query = studentList.Select(s=>s.StudentName);

            foreach(var i in query)
            {
                Console.WriteLine(i);
            }

            var query1 = studentList.First(s => s.StudentID == 1);

            Console.WriteLine("Name:{0} - ID:{1} - Age:{2}",query1.StudentName,query1.StudentID,query1.Age);


            var xyz = studentList.Join(standardList,
                                       student => student.StandardID,
                                       standard => standard.StandardID,
                                       (student, standard) => new
                                       {
                                           StudentName = student.StudentName,
                                           StandardName = standard.StandardName,
                                           Age = student.Age,
                                           StudentID = student.StudentID,
                                      

                                       }).Where(s => s.StudentID == 1);
                                       

            foreach(var i in xyz)
            {
                Console.WriteLine(i);

            }

            Console.ReadLine();
        }


    }
}
