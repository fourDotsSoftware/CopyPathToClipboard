// CopyPathToClipboardShellExt.cpp : Implementation of CCopyPathToClipboardShellExt

#include "stdafx.h"
#include "CopyPathToClipboardShellExt.h"
#include <atlconv.h>  // for ATL string conversion macros
#include "Resource.h"
#include <atlcom.h>
#include <atlstr.h>
#include <stdio.h>
#include <tchar.h>
#define BUFSIZE 65536
#include <cwchar> 

//#include "ShobjIdl.h"
//#include "Shellapi.h"

// CCopyPathToClipboardShellExt
CCopyPathToClipboardShellExt::CCopyPathToClipboardShellExt()
{
	m_hUnlockBmp = LoadBitmap( _AtlBaseModule.GetModuleInstance()  ,
                           MAKEINTRESOURCE(IDB_BITMAP1) );
}


STDMETHODIMP CCopyPathToClipboardShellExt::Initialize ( 
  LPCITEMIDLIST pidlFolder,
  LPDATAOBJECT pDataObj,
  HKEY hProgID )
{
FORMATETC fmt = { CF_HDROP, NULL, DVASPECT_CONTENT, -1, TYMED_HGLOBAL };
STGMEDIUM stg = { TYMED_HGLOBAL };
HDROP     hDrop;

    // Look for CF_HDROP data in the data object.
    if ( FAILED( pDataObj->GetData ( &fmt, &stg ) ))
        {
        // Nope! Return an "invalid argument" error back to Explorer.
        return E_INVALIDARG;
        }

    // Get a pointer to the actual data.
    hDrop = (HDROP) GlobalLock ( stg.hGlobal );

    // Make sure it worked.
    if ( NULL == hDrop )
        return E_INVALIDARG;

    // Sanity check - make sure there is at least one filename.
UINT uNumFiles = DragQueryFile ( hDrop, 0xFFFFFFFF, NULL, 0 );
HRESULT hr = S_OK;

    if ( 0 == uNumFiles )
        {
        GlobalUnlock ( stg.hGlobal );
        ReleaseStgMedium ( &stg );
        return E_INVALIDARG;
        }

	bool isok=false;

	std::vector<LPCWSTR>::iterator it;
	it = m_lsFiles2.begin();		

	for (int k=0;k<uNumFiles;k++)
	{
		LPWSTR m_szFile3=new WCHAR[MAX_PATH];

		if ( 0 != DragQueryFile ( hDrop, k, (LPWSTR) m_szFile3, MAX_PATH ) )
		{
			isok=true;
			it=m_lsFiles2.insert ( it , m_szFile3 );
			//m_lsFiles2.a.push_back(m_szFile);
			
		}
	}
    // Get the name of the first file and store it in our member variable m_szFile.
    //if ( 0 == DragQueryFile ( hDrop, 0, m_szFile, MAX_PATH ) )
    //hr = E_INVALIDARG;

	if (!isok)
	{
		hr = E_INVALIDARG;
	}

    GlobalUnlock ( stg.hGlobal );
    ReleaseStgMedium ( &stg );

    return hr;


}

HRESULT CCopyPathToClipboardShellExt::QueryContextMenu (
  HMENU hmenu, UINT uMenuIndex, UINT uidFirstCmd,
  UINT uidLastCmd, UINT uFlags )
{
  // If the flags include CMF_DEFAULTONLY then we shouldn't do anything.

  if ( uFlags & CMF_DEFAULTONLY )
    return MAKE_HRESULT ( SEVERITY_SUCCESS, FACILITY_NULL, 0 );

	UINT uID = uidFirstCmd;
	UINT upos=-1;
	HMENU hSubmenu = CreatePopupMenu();

// Insert the submenu into the ctx menu provided by Explorer.      
	
	UINT sid=0;	
	upos=0;

	TCHAR name[256];
	LONG res=ERROR_SUCCESS;
	CRegKey rkMenuItems;
	
	DWORD dwErr = ERROR_PATH_NOT_FOUND;
	DWORD dwErrMenuItems = ERROR_PATH_NOT_FOUND;
	TCHAR prch[sizeof(_T("Software\\4dots Software\\CopyPathToClipboard\\MenuItems"))]
	=_T("Software\\4dots Software\\CopyPathToClipboard\\MenuItems");

//	lstrcat(prch,name);	
	dwErrMenuItems = rkMenuItems.Open(HKEY_CURRENT_USER, prch, KEY_QUERY_VALUE);						
	
	// if (m_lsFiles2.size()<=0)
  //{
	//MessageBox ( NULL , _T("Size 0"), _T("SimpleShlExt"),MB_ICONINFORMATION );
  //}
  //else if (m_lsFiles2.size()==1)
  //{
	//MessageBox ( NULL , _T("Size 1"), _T("SimpleShlExt"),MB_ICONINFORMATION );
  //}
  //else if (m_lsFiles2.size()>1)
  //{
	//MessageBox ( NULL , _T("Size >1"), _T("SimpleShlExt"),MB_ICONINFORMATION );
  //}
     	
		TCHAR prcaption[256]={0};
		ULONG prsize=sizeof(prcaption);

		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			dwErr = rkMenuItems.QueryStringValue(_T("Fullpath"), prcaption, &prsize);							
		}
		
		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption,_T("True"))==0) )
			|| dwErr!=ERROR_SUCCESS)
		{
			if (m_lsFiles2.size()==1)
			{
				InsertMenu ( hSubmenu, iCopyFullPath=upos++, MF_BYPOSITION, uID++, _T("Copy Fullpath"));
			}
			else
			{
				InsertMenu ( hSubmenu, iCopyFullPathSpace=upos++, MF_BYPOSITION, uID++, _T("Copy Fullpath	(Space)"));
				InsertMenu ( hSubmenu, iCopyFullPathCRLF=upos++, MF_BYPOSITION, uID++, _T("Copy Fullpath	(CRLF)"));
			}

		}
		
		TCHAR prcaption2[256]={0};
		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			
			dwErr = rkMenuItems.QueryStringValue(_T("Filename"), prcaption2, &prsize);							
		}	

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption2,_T("True"))==0))
			|| dwErr!=ERROR_SUCCESS) 
		{
			if (m_lsFiles2.size()==1)
			{
			InsertMenu ( hSubmenu,iCopyFilename= upos++, MF_BYPOSITION, uID++, _T("Copy Filename"));
			}
			else
			{
				InsertMenu ( hSubmenu,iCopyFilenameSpace=upos++, MF_BYPOSITION, uID++, _T("Copy Filename	(Space)"));
				InsertMenu ( hSubmenu,iCopyFilenameCRLF=upos++, MF_BYPOSITION, uID++, _T("Copy Filename	(CRLF)"));
			}
		}

		TCHAR prcaption02[256] = { 0 };		

		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			dwErr = rkMenuItems.QueryStringValue(_T("Short Fullpath"), prcaption02, &prsize);
		}

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption02, _T("True")) == 0))
			|| dwErr != ERROR_SUCCESS)
		{
			if (m_lsFiles2.size() == 1)
			{
				InsertMenu(hSubmenu, iCopyShortFullPath = upos++, MF_BYPOSITION, uID++, _T("Copy Short Fullpath"));
			}
			else
			{
				InsertMenu(hSubmenu, iCopyShortFullPathSpace = upos++, MF_BYPOSITION, uID++, _T("Copy Short Fullpath	(Space)"));
				InsertMenu(hSubmenu, iCopyShortFullPathCRLF = upos++, MF_BYPOSITION, uID++, _T("Copy Short Fullpath	(CRLF)"));
			}
		}

		TCHAR prcaption01[256] = { 0 };
		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{

			dwErr = rkMenuItems.QueryStringValue(_T("Short Filename"), prcaption01, &prsize);
		}

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption01, _T("True")) == 0))
			|| dwErr != ERROR_SUCCESS)
		{
			if (m_lsFiles2.size() == 1)
			{
				InsertMenu(hSubmenu, iCopyShortFilename = upos++, MF_BYPOSITION, uID++, _T("Copy Short Filename"));
			}
			else
			{
				InsertMenu(hSubmenu, iCopyShortFilenameSpace = upos++, MF_BYPOSITION, uID++, _T("Copy Short Filename	(Space)"));
				InsertMenu(hSubmenu, iCopyShortFilenameCRLF = upos++, MF_BYPOSITION, uID++, _T("Copy Short Filename	(CRLF)"));
			}
		}

		TCHAR prcaption3[256]={0};
		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			dwErr = rkMenuItems.QueryStringValue(_T("ParentFolder"), prcaption3, &prsize);							
		}	

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption3,_T("True"))==0))
			|| dwErr!=ERROR_SUCCESS) 
		{
			
			InsertMenu ( hSubmenu,iCopyParentFolderPath=upos++, MF_BYPOSITION, uID++, _T("Copy Parent Folder Path"));
			

		}

		TCHAR prcaption4[256]={0};
		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			dwErr = rkMenuItems.QueryStringValue(_T("Copy URL Filename"), prcaption4, &prsize);							
		}	

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption4,_T("True"))==0))
			|| dwErr!=ERROR_SUCCESS) 
		{
			if (m_lsFiles2.size()==1)
			{
			InsertMenu ( hSubmenu,iCopyURLEncodedPath=upos++, MF_BYPOSITION, uID++, _T("Copy URL Filename"));
			}
			else
			{
				InsertMenu ( hSubmenu,iCopyURLEncodedPathSpace=upos++, MF_BYPOSITION, uID++, _T("Copy URL Filename	(Space)"));
				InsertMenu ( hSubmenu,iCopyURLEncodedPathCRLF=upos++, MF_BYPOSITION, uID++, _T("Copy URL Filename	(CRLF)"));
			}

		}


		TCHAR prcaption5[256]={0};

		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			dwErr = rkMenuItems.QueryStringValue(_T("Copy Relative Path"), prcaption5, &prsize);							
		}	

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption5,_T("True"))==0))
			|| dwErr!=ERROR_SUCCESS) 
		{
			if (m_lsFiles2.size()==1)
			{
			InsertMenu ( hSubmenu,iCopyRelativePath=upos++, MF_BYPOSITION, uID++, _T("Copy Relative Path"));
			}
			else
			{
				InsertMenu ( hSubmenu,iCopyRelativePathSpace=upos++, MF_BYPOSITION, uID++, _T("Copy Relative Path	(Space)"));
				InsertMenu ( hSubmenu,iCopyRelativePathCRLF=upos++, MF_BYPOSITION, uID++, _T("Copy Relative Path	(CRLF)"));
			}

		}

		TCHAR prcaption6[256]={0};
		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			dwErr = rkMenuItems.QueryStringValue(_T("Copy URL Relative Path"), prcaption6, &prsize);							
		}	

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption6,_T("True"))==0))
			|| dwErr!=ERROR_SUCCESS) 
		{
			if (m_lsFiles2.size()==1)
			{
			InsertMenu ( hSubmenu,iCopyURLEncodedRelativePath=upos++, MF_BYPOSITION, uID++, _T("Copy URL Relative Path"));
			}
			else
			{
				InsertMenu ( hSubmenu,iCopyURLEncodedRelativePathSpace=upos++, MF_BYPOSITION, uID++, _T("Copy URL Relative Path	(Space)"));
				InsertMenu ( hSubmenu,iCopyURLEncodedRelativePathCRLF=upos++, MF_BYPOSITION, uID++, _T("Copy URL Relative Path	(CRLF)"));
			}
		}

		TCHAR prcaption7[256]={0};
		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			
			dwErr = rkMenuItems.QueryStringValue(_T("Filename Without Extension"), prcaption7, &prsize);							
		}	

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption7,_T("True"))==0))
			|| dwErr!=ERROR_SUCCESS) 
		{
			if (m_lsFiles2.size()==1)
			{
			InsertMenu ( hSubmenu,iCopyFilenameNoExt= upos++, MF_BYPOSITION, uID++, _T("Copy Filename without Extension"));
			}
			else
			{
				InsertMenu ( hSubmenu,iCopyFilenameNoExtSpace=upos++, MF_BYPOSITION, uID++, _T("Copy Filename without Extension	(Space)"));
				InsertMenu ( hSubmenu,iCopyFilenameNoExtCRLF=upos++, MF_BYPOSITION, uID++, _T("Copy Filename without Extension	(CRLF)"));
			}
		}

		TCHAR prcaption8[256]={0};
		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			dwErr = rkMenuItems.QueryStringValue(_T("Copy UNC Path"), prcaption8, &prsize);							
		}	

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption8,_T("True"))==0))
			|| dwErr!=ERROR_SUCCESS) 
		{
			if (m_lsFiles2.size()==1)
			{
			InsertMenu ( hSubmenu,iCopyUNCPath=upos++, MF_BYPOSITION, uID++, _T("Copy UNC Path"));
			}
			else
			{
				InsertMenu ( hSubmenu,iCopyUNCPathSpace=upos++, MF_BYPOSITION, uID++, _T("Copy UNC Path	(Space)"));
				InsertMenu ( hSubmenu,iCopyUNCPathCRLF=upos++, MF_BYPOSITION, uID++, _T("Copy UNC Path	(CRLF)"));
			}
		}

		TCHAR prcaption9[256]={0};
		dwErr = ERROR_PATH_NOT_FOUND;
		if (dwErrMenuItems == ERROR_SUCCESS)
		{
			dwErr = rkMenuItems.QueryStringValue(_T("Settings"), prcaption9, &prsize);							
		}	

		if ((dwErr == ERROR_SUCCESS && (lstrcmp(prcaption9,_T("True"))==0))
			|| dwErr!=ERROR_SUCCESS) 
		{
			InsertMenu ( hSubmenu, upos++, MF_BYPOSITION | MF_SEPARATOR, uID++, NULL);
			InsertMenu ( hSubmenu, iSettings=upos++, MF_BYPOSITION, uID++, _T("&Settings"));	
		}

		
	
    MENUITEMINFO mii = { sizeof(MENUITEMINFO) };

    mii.fMask = MIIM_SUBMENU | MIIM_STRING | MIIM_ID;
    mii.wID = uID++;
    mii.hSubMenu = hSubmenu;
    mii.dwTypeData = _T("Copy &Path to Clipboard");

    InsertMenuItem ( hmenu, uMenuIndex, TRUE, &mii );

	if ( NULL != m_hUnlockBmp) 
    SetMenuItemBitmaps ( hmenu, uMenuIndex, MF_BYPOSITION, m_hUnlockBmp, m_hUnlockBmp );

    return MAKE_HRESULT ( SEVERITY_SUCCESS, FACILITY_NULL, uID - uidFirstCmd );
	
	//return MAKE_HRESULT ( SEVERITY_SUCCESS, FACILITY_NULL, 1 );
}


HRESULT CCopyPathToClipboardShellExt::GetCommandString (
  UINT_PTR idCmd, UINT uFlags, UINT* pwReserved,
//  UINT idCmd, UINT uFlags, UINT* pwReserved,
  LPSTR pszName, UINT cchMax )

{
USES_CONVERSION;		

return E_INVALIDARG;
  // Check idCmd, it must be 0 since we have only one menu item.

 // if ( 0 != idCmd )
  //  return E_INVALIDARG;
//	return E_FAIL;
 
  // If Explorer is asking for a help string, copy our string into the

  // supplied buffer.
  
  if (uFlags==GCS_VALIDATE)
  {
	return NOERROR;
  }
  else if ( uFlags == GCS_HELPTEXT || uFlags==GCS_HELPTEXTW)
    {
    LPCTSTR szText = _T("Copy Path to Clipboard");	

	//HINSTANCE hInst = AfxGetInstanceHandle();
    if ( uFlags & GCS_UNICODE )
      {
      // We need to cast pszName to a Unicode string, and then use the

      // Unicode string copy API.

      lstrcpynW ( (LPWSTR) pszName, T2CW(szText), cchMax );
      }
    else
      {
      // Use the ANSI string copy API to return the help string.

      lstrcpynA ( pszName, T2CA(szText), cchMax );
      }
 
    return S_OK;
	//return NOERROR;
    }
	else if ( uFlags == GCS_VERB || uFlags==GCS_VERBW)
    {
	//	MessageBox ( NULL , _T("gcs_verb"), _T("SimpleShlExt"),MB_ICONINFORMATION );
    LPCTSTR szText = _T("CopyPathToClipboard");
 
    if ( uFlags & GCS_UNICODE )
      {
      // We need to cast pszName to a Unicode string, and then use the

      // Unicode string copy API.

      lstrcpynW ( (LPWSTR) pszName, T2CW(szText), cchMax );
      }
    else
      {
      // Use the ANSI string copy API to return the help string.

      lstrcpynA ( pszName, T2CA(szText), cchMax );
      }
 
    return S_OK;
	//return NOERROR;
    }
 
   
  //return E_INVALIDARG;
  return S_OK;
}

HRESULT CCopyPathToClipboardShellExt::InvokeCommand(
  LPCMINVOKECOMMANDINFO pCmdInfo)
{
  // If lpVerb really points to a string, ignore this function call and bail out.
/*
	BOOL fEx = FALSE;
    BOOL fUnicode = FALSE;

    if(pCmdInfo->cbSize == sizeof(CMINVOKECOMMANDINFOEX))
    {
        fEx = TRUE;
        if((lpcmi->fMask & CMIC_MASK_UNICODE))
        {
            fUnicode = TRUE;
        }
    }

    if( !fUnicode && HIWORD(pCmdInfo->lpVerb))
    {
		  if ( 0 != HIWORD( pCmdInfo->lpVerb) )
			return E_INVALIDARG;
		/*
        if(StrCmpIA(lpcmi->lpVerb, m_pszVerb))
        {
            return E_FAIL;
        }*/
   // }
/*
    else if( fUnicode && HIWORD(((CMINVOKECOMMANDINFOEX *) pCmdInfo)->lpVerbW))
    {
        if(StrCmpIW(((CMINVOKECOMMANDINFOEX *)lpcmi)->lpVerbW, m_pwszVerb))
        {
            return E_FAIL;
        }
    }

    else if(LOWORD(lpcmi->lpVerb) != IDM_DISPLAY)
    {
        return E_FAIL;
    }
*/
	//MessageBox ( NULL ,_T("Invokecmd0"), _T("SimpleShlExt"),MB_ICONINFORMATION );

  if ( 0 != HIWORD( pCmdInfo->lpVerb) )
    return E_INVALIDARG;
 
  //MessageBox ( NULL ,_T("Invokecmd"), _T("SimpleShlExt"),MB_ICONINFORMATION );

	HANDLE hFile;
	HANDLE hTempFile;
	DWORD dwRetVal;
	DWORD dwBytesRead;
	DWORD dwBytesWritten;
	DWORD dwBufSize = BUFSIZE;
	UINT uRetVal;
	WCHAR szTempName[MAX_PATH] = TEXT("just_dummy");
	//LPWSTR buffer = malloc(sizeof(BUFSIZE));
	WCHAR lpPathBuffer[MAX_PATH] = TEXT("just_dummy");
	BOOL fSuccess;

  // Get the command index - the only valid one is 0.  		

	
// Get the temp path.
dwRetVal = GetTempPath(dwBufSize, // length of the buffer
lpPathBuffer); // buffer for path
if (dwRetVal > dwBufSize)
{
return E_INVALIDARG;
}
else
{

lstrcatW(lpPathBuffer,_T("copypathtoclipboardtmp.txt"));


//MessageBox ( NULL , lpPathBuffer, _T("SimpleShlExt"),
 //                  MB_ICONINFORMATION );


}

/*
// Create a temporary file.
uRetVal = GetTempFileName(lpPathBuffer, // directory for tmp files
L"NEW", // temp file name prefix
0, // create unique name
szTempName); // buffer for the name

MessageBox ( NULL , szTempName, _T("SimpleShlExt"),
                   MB_ICONINFORMATION );


if (uRetVal == 0)
{
return E_INVALIDARG;
}

MessageBox ( NULL , _T("TEMPFILEGET"), _T("SimpleShlExt"),
                   MB_ICONINFORMATION );
*/
// Create the new file to write the upper-case version to.
hTempFile = CreateFile((LPTSTR) lpPathBuffer, // file name
GENERIC_READ | GENERIC_WRITE, // open r-w
0, // do not share
NULL, // default security
CREATE_ALWAYS, // overwrite existing
FILE_ATTRIBUTE_NORMAL,// normal file
NULL); // no template
 

//MessageBox ( NULL , _T("TEMPFILECREATED"), _T("SimpleShlExt"),MB_ICONINFORMATION );

if (hTempFile == INVALID_HANDLE_VALUE)
{
	return E_INVALIDARG;
}


  int iVerb=LOWORD(pCmdInfo->lpVerb);

   WCHAR sParam[40000];
   lstrcpyW(sParam,_T(" "));
/*
   lstrcpyW(sParam,_T("-Imgs:"));
   lstrcpyW(sParam,_T("\""));
   lstrcatW(sParam,m_szFile);
   lstrcatW(sParam,_T("\""));
*/

  for (int k=0;k<m_lsFiles2.size();k++)
  {
	//MessageBox ( NULL , (LPCWSTR)m_lsFiles2[k], _T("SimpleShlExt"),
	//				MB_ICONINFORMATION );

   lstrcatW(sParam,_T("\""));
   lstrcatW(sParam,(WCHAR*)m_lsFiles2[k]);
   lstrcatW(sParam,_T("\" "));
  }

  bool only_one_file=true;

  if (m_lsFiles2.size()>1)
  {
	only_one_file=false;
  }

 

 // lstrcatW(sParam,_T(" -Cmd:"));

  //  switch ( LOWORD( pCmdInfo->lpVerb ) )

  WCHAR cmd[100];

CString cstr;
cstr.Format(_T("%d"),iVerb);

  //MessageBox ( NULL ,cstr , _T("SimpleShlExt"),MB_ICONINFORMATION );	    

if (iVerb==iCopyFullPath && only_one_file)
{
lstrcatW(sParam,_T(" -CopyFullPath"));
}
else if (iVerb == iCopyShortFullPath && only_one_file)
{
	lstrcatW(sParam, _T(" -CopyShortFullPath"));
}
else if (iVerb==iCopyUNCPath && only_one_file)
{
	lstrcatW(sParam,_T(" -CopyUNCPath"));
}
else if (iVerb==iCopyFilename && only_one_file)
{
	lstrcatW(sParam,_T(" -CopyFilename"));
}
else if (iVerb == iCopyShortFilename && only_one_file)
{
	lstrcatW(sParam, _T(" -CopyShortFilename"));
}
else if (iVerb==iCopyFilenameNoExt && only_one_file)
{
	lstrcatW(sParam,_T(" -CopyFilenameNoExt"));
}
else if (iVerb==iCopyParentFolderPath)
{
	lstrcatW(sParam,_T(" -CopyParentFolderPath"));
}
else if (iVerb==iCopyRelativePath && only_one_file)
{
	lstrcatW(sParam,_T(" -CopyRelativePath"));
}
else if (iVerb==iCopyURLEncodedRelativePath && only_one_file)
{
	lstrcatW(sParam,_T(" -CopyURLEncodedRelativePath"));
}
else if (iVerb==iCopyURLEncodedPath && only_one_file)
{
	lstrcatW(sParam,_T(" -CopyURLEncodedPath"));
}

else if (iVerb==iCopyFullPathSpace)
{
	lstrcatW(sParam,_T(" -CopyFullPathSpace"));
}
else if (iVerb==iCopyFullPathCRLF)
{
	lstrcatW(sParam,_T(" -CopyFullPathCRLF"));
}
else if (iVerb == iCopyShortFullPathSpace)
{
	lstrcatW(sParam, _T(" -CopyShortFullPathSpace"));
}
else if (iVerb == iCopyShortFullPathCRLF)
{
	lstrcatW(sParam, _T(" -CopyShortFullPathCRLF"));
}

else if (iVerb==iCopyFilenameSpace)
{
	lstrcatW(sParam,_T(" -CopyFilenameSpace"));
}
else if (iVerb==iCopyFilenameCRLF)
{
	lstrcatW(sParam,_T(" -CopyFilenameCRLF"));
}
else if (iVerb == iCopyShortFilenameSpace)
{
	lstrcatW(sParam, _T(" -CopyFilenameSpace"));
}
else if (iVerb == iCopyShortFilenameCRLF)
{
	lstrcatW(sParam, _T(" -CopyFilenameCRLF"));
}

else if (iVerb==iCopyFilenameNoExtSpace)
{
	lstrcatW(sParam,_T(" -CopyFilenameNoExtSpace"));
}
else if (iVerb==iCopyFilenameNoExtCRLF)
{
	lstrcatW(sParam,_T(" -CopyFilenameNoExtCRLF"));
}

else if (iVerb==iCopyParentFolderPathSpace)
{
	lstrcatW(sParam,_T(" -CopyParentFolderPathSpace"));
}
else if (iVerb==iCopyParentFolderPathCRLF)
{
	lstrcatW(sParam,_T(" -CopyParentFolderPathCRLF"));
}
else if (iVerb==iCopyRelativePathSpace)
{
	lstrcatW(sParam,_T(" -CopyRelativePathSpace"));
}
else if (iVerb==iCopyRelativePathCRLF)
{
	lstrcatW(sParam,_T(" -CopyRelativePathCRLF"));
}
else if (iVerb==iCopyURLEncodedPathSpace)
{
	lstrcatW(sParam,_T(" -CopyURLEncodedPathSpace"));
}
else if (iVerb==iCopyURLEncodedPathCRLF)
{
	lstrcatW(sParam,_T(" -CopyURLEncodedPathCRLF"));
}
else if (iVerb==iCopyURLEncodedRelativePathSpace)
{
	lstrcatW(sParam,_T(" -CopyURLEncodedRelativePathSpace"));
}
else if (iVerb==iCopyURLEncodedRelativePathCRLF)
{
	lstrcatW(sParam,_T(" -CopyURLEncodedRelativePathCRLF"));
}

else if (iVerb==iCopyUNCPathSpace)
{
	lstrcatW(sParam,_T(" -CopyUNCPathSpace"));
}
else if (iVerb==iCopyUNCPathCRLF)
{
	lstrcatW(sParam,_T(" -CopyUNCPathCRLF"));
}
else if (iVerb==iSettings)
{
	lstrcatW(sParam,_T(" -Settings"));
}

//lstrcatW(sParam,cmd);

      
	//MessageBox ( NULL , sParam, _T("SimpleShlExt"),MB_ICONINFORMATION );	    

		WCHAR szMsg[MAX_PATH + 32];
	    CRegKey reg;
        LONG    lRet;

        lRet = reg.Open ( HKEY_LOCAL_MACHINE,
                          _T("Software\\4dots Software\\CopyPathToClipboard"),KEY_QUERY_VALUE);

		//MessageBox ( NULL , _T("test"), _T("SimpleShlExt"),
        //         MB_ICONINFORMATION );	    

		if (lRet!=ERROR_SUCCESS)
		{
			return E_UNEXPECTED;
		}

		TCHAR szFp[MAX_PATH];		
		DWORD dwSizeFp = sizeof(szFp) / sizeof(TCHAR); // # of characters in the buffer 
		
		lRet=reg.QueryStringValue(_T("InstallationDirectory"),szFp,&dwSizeFp);
 
		if (lRet!=ERROR_SUCCESS)
		{
			return E_UNEXPECTED;
		}

		//MessageBox ( NULL , _T("test2"), _T("SimpleShlExt"),
         //        MB_ICONINFORMATION );	    

		
		//MessageBox ( pCmdInfo->hwnd, m_szFile, _T("SimpleShlExt"),
          //         MB_ICONINFORMATION );


		//ShellExecute(NULL, _T("open"), _T("test.txt"), NULL, _T("."),SW_SHOWNORMAL);
		TCHAR szFp2[MAX_PATH];
		//szFp=lstrcat(szFp,_T("ImgTransformer.exe"));

		
		wcscat_s(szFp,_T("\\CopyPathToClipboard.exe") );

		//MessageBox ( pCmdInfo->hwnd, szFp, _T("SimpleShlExt"),
          //         MB_ICONINFORMATION );
		
		
		//28.9.11 lstrcpyW(szMsg,_T("-showunlockfile "));

		
		lstrcpyW(szFp2,_T("\""));
		lstrcatW(szFp2,szFp);
		lstrcatW(szFp2,_T("\""));
		

		WCHAR szTempParam[MAX_PATH];
		lstrcpyW(szTempParam,_T("-TempFile:\""));
		lstrcatW(szTempParam,lpPathBuffer);
		lstrcatW(szTempParam,_T("\""));

		//wcscat_s(szMsg,_T("-showunlockfile "));
		//wcscat_s(szMsg,m_szFile);

		//wsprintf ( szMsg, _T("-showunlockfile "), m_szFile );
		//szMsg=lstrcat(_T("-showunlockfile "),m_szFile);
				
		//MessageBox ( pCmdInfo->hwnd, szMsg, _T("SimpleShlExt"),
          //         MB_ICONINFORMATION );

		//1ShellExecute(NULL, _T("open"), szFp, szMsg, _T("."), SW_SHOWNORMAL);


		//MessageBox ( NULL , sParam, _T("SimpleShlExt"),
       //          MB_ICONINFORMATION );	    

		//MessageBox ( NULL , szFp2, _T("SimpleShlExt"),
        //         MB_ICONINFORMATION );	    

	//	ShellExecute(NULL, _T("open"), szFp2, sParam, _T("."), SW_SHOWNORMAL);

		
	//MessageBox ( pCmdInfo->hwnd, szTempName, _T("SimpleShlExt"),
	//                   MB_ICONINFORMATION );
		
		//MessageBox ( NULL, _T("OK1"), _T("SimpleShlExt"),MB_ICONINFORMATION );

		fSuccess = WriteFile(hTempFile,
		sParam,
		std::wcslen (sParam)*sizeof(wchar_t),
		&dwBytesWritten,
		NULL);

		//MessageBox ( NULL, _T("OK2"), _T("SimpleShlExt"),MB_ICONINFORMATION );

		CloseHandle (hTempFile);

		//MessageBox ( NULL, _T("OK3"), _T("SimpleShlExt"),MB_ICONINFORMATION );
		if (!fSuccess)
		{
		return E_INVALIDARG;
		}
		//removeShellExecute(NULL, _T("open"), szFp2, sParam, _T("."), SW_SHOWNORMAL);
        ShellExecute(NULL, _T("open"), szFp2, szTempParam, _T("."), SW_SHOWNORMAL);

		//wsprintf ( szMsg, _T("The selected file was:\n\n%s"), m_szFile );
 
		//MessageBox ( NULL, _T("OK"), _T("SimpleShlExt"),MB_ICONINFORMATION );
 
      return S_OK;
   }


  


