using System.Text;

public class RemoteJobOffer : JobOffer
{
    public bool FullyRemote { get; }

    public RemoteJobOffer(string jobTitle, string company, double salary, bool fullyRemote)
        : base(jobTitle, company, salary)
    {
        this.FullyRemote = fullyRemote;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());

        string fullyRemoteWord = this.FullyRemote ? "yes" : "no";
        sb.Append($"Fully Remote: {fullyRemoteWord}");

        return sb.ToString();
    }
}

