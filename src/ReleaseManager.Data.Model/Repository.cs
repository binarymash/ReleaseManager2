namespace ReleaseManager.Data.Model
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Repository
    {
        public int RepositoryId { get; private set; }

        public string Path { get; set; }

        public Repository(int id)
        {
            RepositoryId = id;
        }
    }
}
