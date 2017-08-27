"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.1A\Bin\makecert.exe" ^
-n "CN=%1" ^
-r ^
-pe ^
-sky exchange ^
-sv %1.pvk ^
%1.cer


"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.1A\Bin\pvk2pfx.exe" ^
-pvk %1.pvk ^
-spc %1.cer ^
-pfx %1.pfx ^
-po Test123