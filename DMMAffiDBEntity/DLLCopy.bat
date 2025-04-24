set CONFIGURATION=%1

set FROM_DLL_FILE=%2%3.dll
set FROM_XML_FILE=%2%3.xml
set FROM_PDB_FILE=%2%3.pdb
set FROM_DEPS_JSON_FILE=%2%3.deps.json

set TO_PROJECT_DIT=%4..\DLL\

set DELETE_PDB_FILE=%4..\DLL\%3.pdb
set DELETE_DEPS_JSON_FILE=%4..\DLL\%3.deps.json

if %CONFIGURATION% == "Release" (
    if exist %DELETE_PDB_FILE% (
        del %DELETE_PDB_FILE%
    )

    if exist %DELETE_DEPS_JSON_FILE% (
        del %DELETE_DEPS_JSON_FILE%
    )

    xcopy %FROM_DLL_FILE% %TO_PROJECT_DIT% /Y
    xcopy %FROM_XML_FILE% %TO_PROJECT_DIT% /Y
) else (
    xcopy %FROM_PDB_FILE% %TO_PROJECT_DIT% /Y
    xcopy %FROM_DEPS_JSON_FILE% %TO_PROJECT_DIT% /Y

    xcopy %FROM_DLL_FILE% %TO_PROJECT_DIT% /Y
    xcopy %FROM_XML_FILE% %TO_PROJECT_DIT% /Y
)