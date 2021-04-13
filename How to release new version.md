## Releasing a new version of Prism

### Summary
- Change release date in app
- Build Release version & zip up
- Create release on GitHub
- Update versioning table on database

### Detail
frm_HomePage.cs --> replace date parts with date of release (usually today):
	DateTime thisRelease = new DateTime(yyyy, mm, dd);
commit change and push to remote.

Change build type from Debug to Release and build.  
Navigate to \..\DAT_CMS\CMS\CMS\bin\Release  
Disregard any \*.pdb and \*.config files but put the rest into a folder called 'Prism' and zip to 'Prism vX.zip'

From remote go to '[Releases](https://github.com/AdamKeeley/DAT_CMS/releases)' and 'Draft a new release'.
Enter the version number in 'Tag version' and a version name in 'Release title'.
Upload 'Prism vX.zip' to the release.
Publish release.

Note the URL of the new release (e.g. https://github.com/AdamKeeley/DAT_CMS/releases/tag/v1.1.0.0)

Run the following SQL against the CMS database:
```TSQL
insert into [dbo].[versioning] ([VersionName], [ReleaseURL]) values (@versionName, @releaseURL)
```
- @versionName is the concateneated version number and version name
- @releaseURL is the URL of the new release
