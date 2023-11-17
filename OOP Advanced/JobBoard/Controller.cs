using System;
using System.Collections.Generic;


public class Controller
{
    private readonly Dictionary<string, Category> categories = new Dictionary<string, Category>();

    public string AddCategory(List<string> args)
    {
        string name = args[0];
        Category category = new Category(name);

        this.categories[name] = category;
        return $"Created Category {name}!";
    }

    public string AddJobOffer(List<string> args)
    {
        string name = args[0];
        string jobTitle = args[1];
        string company = args[2];
        double salary = double.Parse(args[3]);
        string type = args[4];

        JobOffer jobOffer = null;
        if (type == "onsite")
        {
            string city = args[5];
            jobOffer = new OnSiteJobOffer(jobTitle, company, salary, city);
        }
        else if (type == "remote")
        {
            bool fullyRemote = bool.Parse(args[5]);
            jobOffer = new RemoteJobOffer(jobTitle, company, salary, fullyRemote);
        }

        this.categories[name].AddJobOffer(jobOffer);

        return $"Created JobOffer {jobTitle} in Category {name}!";
    }

    public string GetAverageSalary(List<string> args)
    {
        string name = args[0];
        double averageSalary = this.categories[name].AverageSalary();

        return $"The average salary is: {averageSalary:f2} BGN";
    }

    public string GetOffersAboveSalary(List<string> args)
    {
        string name = args[0];
        double salary = double.Parse(args[1]);

        List<JobOffer> offers = this.categories[name].GetOffersAboveSalary(salary);
        return string.Join(Environment.NewLine, offers);
    }

    public string GetOffersWithoutSalary(List<string> args)
    {
        string name = args[0];

        List<JobOffer> offers = this.categories[name].GetOffersWithoutSalary();
        return string.Join(Environment.NewLine, offers);
    }
}