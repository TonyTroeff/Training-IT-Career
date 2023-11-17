using System;
using System.Text;

public abstract class JobOffer
{
    public string JobTitle { get; }
    public string Company { get; }
    public double Salary { get; }

    public JobOffer(string jobTitle, string company, double salary)
    {
        if (jobTitle == null || jobTitle.Length < 3 || jobTitle.Length > 30)
            throw new ArgumentException("JobTitle should be between 3 and 30 characters!");
        if (company == null || company.Length < 3 || company.Length > 30)
            throw new ArgumentException("Company should be between 3 and 30 characters!");
        if (salary < 0)
            throw new ArgumentException("Salary should be 0 or positive!");

        this.JobTitle = jobTitle;
        this.Company = company;
        this.Salary = salary;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Job Title: {this.JobTitle}");
        sb.AppendLine($"Company: {this.Company}");
        sb.Append($"Salary: {this.Salary:f2} BGN");

        return sb.ToString();
    }
}
