// See https://aka.ms/new-console-template for more information
using LibGit2Sharp;
using System;
using LibGit2Sharp;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Replace this path with the path to your repository
        string repoPath = "/Users/hanneskuss/Dev/gittest";
        // jojo
        
        using (var repo = new Repository(repoPath))
        {
            // Replace "your-branch-name" with the name of the branch you want to get commits from
            var branch = repo.Branches["next"];

            if (branch == null)
            {
                Console.WriteLine("Branch not found");
                return;
            }

            var commits = new HashSet<Commit>();

            foreach (var commit in branch.Commits)
            {
                // Check if the commit is reachable from the specified branch
                if (repo.Commits.QueryBy(new CommitFilter
                    {
                        IncludeReachableFrom = repo.Branches["next"],
                        ExcludeReachableFrom = repo.Branches["main"].Tip,
                        SortBy = CommitSortStrategies.Topological | CommitSortStrategies.Time,
                    }).Any(c => c.Sha == commit.Sha))
                {
                    commits.Add(commit);
                }
            }

            Console.WriteLine($"Distinct commits count: {commits.Count}");

            // Print out the commit SHA and message for each distinct commit
            foreach (var commit in commits)
            {
                Console.WriteLine($"Commit: {commit.Sha}, Message: {commit.Message}");
            }
        }
    }
}
// Der nächste Test
// lol aaa
aaa
aaa
aaa
