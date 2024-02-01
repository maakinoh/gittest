// See https://aka.ms/new-console-template for more information
using LibGit2Sharp;

Console.WriteLine("Hello, World!");

var repo = new Repository("./.git");

foreach (var commit in repo.Commits)
{
    var parents = commit.Parents;
    foreach (var parent in parents)
    {
        var diff = repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree);
        foreach (var ad in diff.Added)
        {
            Console.WriteLine(ad.Path);
        }
    }
}
