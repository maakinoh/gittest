﻿// See https://aka.ms/new-console-template for more information
using LibGit2Sharp;

Console.WriteLine("Hello, World!");

var repo = new Repository("/Users/hanneskuss/Dev/gittest/");

Dictionary<String, Dictionary<String,int>> fileHist = new Dictionary<string, Dictionary<String,int>>();

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
        foreach (var ad in diff.Modified)
        {
            if (fileHist.ContainsKey(ad.Path))
            {
                if (fileHist[ad.Path].ContainsKey(commit.Author.Email))
                {
                    fileHist[ad.Path][commit.Author.Email] += 1;
                }
                else
                {
                    fileHist[ad.Path][commit.Author.Email] = 1;
                }
            }
            else
            {
                fileHist[ad.Path] = new Dictionary<string, int>();
                fileHist[ad.Path][commit.Author.Email] = 1;
            }
            Console.WriteLine(ad.Path);
        }
    }
    
    
}
