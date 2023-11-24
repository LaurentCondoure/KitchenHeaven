nuget.exe pack KitchenHeaven.FrameWork.nuspec

nuget push pack KitchenHeaven.FrameWork.nupkg -apikey PAM -Source 
nuget add KitchenHeaven.FrameWork.nupkg -source 
pause