using System;
using LibGit2Sharp;

namespace ReleaseManager.Data.Git
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class GitManager
    {
        public void Get(string path)
        {
            using (var repo = new Repository(path))
            {
                var filter = new CommitFilter { Since = repo.Branches["master"], Until = repo.Branches["development"] };

                var commits = repo.Commits.QueryBy(filter);

                foreach (var commit in commits)
                {
                    Console.WriteLine(commit.Id);   // Of course the output can be prettified ;-)
                }
            }
        }
    }
}
