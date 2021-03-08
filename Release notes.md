## Releasing a new version of Prism

frm_HomePage.cs --> replace date parts with date of release (usually today):
	DateTime thisRelease = new DateTime(yyyy, mm, dd);
commit change and push to remote.

From remote go to '[Releases](https://github.com/AdamKeeley/DAT_CMS/releases)' and 'Draft a new release'.
Enter the version number in 'Tag version' and a version name in 'Release title'.
Publish release.

Note the URL of the new release (e.g. https://github.com/AdamKeeley/DAT_CMS/releases/tag/v1.1.0.0)

Run the following SQL against the CMS database:
```TSQL
insert into [dbo].[versioning] ([VersionName], [ReleaseURL]) values (@versionName, @releaseURL)
```
- @versionName is the concateneated version number and version name
- @releaseURL is the URL of the new release
