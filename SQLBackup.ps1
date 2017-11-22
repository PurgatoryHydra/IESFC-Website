$stringDate = Get-Date -Format FileDate
$stringName = -join("SQLBackup_", $stringDate)
echo $stringName
mkdir $stringName
cp -Force E:\Users\Duke\Desktop\CSharpGL\commit.bat $stringName\commit.bat
cd $stringName
$string7z = -join("..\", $stringName, ".7z")
7z a -bb3 $string7z *
cd ..
rm -Recurse -Force $stringName
$stringName = -join($stringName, ".7z")
$returnValue = python Backup.py $stringName
if($returnValue -notmatch "Error")
{
    rm -Force $stringName
    echo 'Backup Succeeded.'
}
else
{
    echo 'Email Failed.'
}