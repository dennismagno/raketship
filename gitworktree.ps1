param(
	[string]$rootPath,
    [string]$branchName,
    [string]$folderName
)

cd $rootPath
git checkout master
git fetch
if (git rev-parse --verify --quiet $branchName) 
{ 
	git worktree add  ../$folderName $branchName
} 
else 
{ 
	git worktree add  -b $branchName ../$folderName
	git push --set-upstream origin $branchName
}