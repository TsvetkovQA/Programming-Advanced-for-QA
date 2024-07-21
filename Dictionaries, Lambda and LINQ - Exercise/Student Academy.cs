Dictionary<string, List<double>> studentsGrade = new Dictionary<string, List<double>>();



int countStudents = int.Parse(Console.ReadLine());

for (int count = 1; count <= countStudents; count++)
{
    string studentName = Console.ReadLine();
    double grade = double.Parse(Console.ReadLine());

   
    if (!studentsGrade.ContainsKey(studentName))
    {
       
        studentsGrade.Add(studentName, new List<double>());
        studentsGrade[studentName].Add(grade);
    }
    
    else
    {
        studentsGrade[studentName].Add(grade);
    } 
}


foreach(KeyValuePair<string, List<double>> entry in studentsGrade)
{
   
    double averageGrade = entry.Value.Average();
    if (averageGrade >= 4.50)
    {
        Console.WriteLine($"{entry.Key} -> {averageGrade:F2}");
    }
}