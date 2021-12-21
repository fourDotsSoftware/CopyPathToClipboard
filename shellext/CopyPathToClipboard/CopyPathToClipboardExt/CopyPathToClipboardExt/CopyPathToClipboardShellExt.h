// CopyPathToClipboardShellExt.h : Declaration of the CCopyPathToClipboardShellExt

#pragma once
#include "resource.h"       // main symbols
#include <sstream>
#include <vector>
#include "CopyPathToClipboardExt_i.h"
/*
//start
#include <shlobj.h>
#include <comdef.h>
//end
*/

#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CCopyPathToClipboardShellExt

class ATL_NO_VTABLE CCopyPathToClipboardShellExt :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCopyPathToClipboardShellExt, &CLSID_CopyPathToClipboardShellExt>,
	public IShellExtInit,
	public IContextMenu
	
	//public ICopyPathToClipboardShellExt
{
public:
	CCopyPathToClipboardShellExt();
	

DECLARE_REGISTRY_RESOURCEID(IDR_HANDYRESIZERSHELLEXT)

DECLARE_NOT_AGGREGATABLE(CCopyPathToClipboardShellExt)

BEGIN_COM_MAP(CCopyPathToClipboardShellExt)
	//COM_INTERFACE_ENTRY(ICopyPathToClipboardShellExt)
	COM_INTERFACE_ENTRY(IShellExtInit)
	COM_INTERFACE_ENTRY(IContextMenu)
END_COM_MAP()

	 int iCopyFullPath;
	 int iCopyFullPathSpace;
	 int iCopyFullPathCRLF;
	 int iCopyFilename;
	 int iCopyFilenameSpace;
	 int iCopyFilenameCRLF;

	 int iCopyShortFullPath;
	 int iCopyShortFullPathSpace;
	 int iCopyShortFullPathCRLF;
	 int iCopyShortFilename;
	 int iCopyShortFilenameSpace;
	 int iCopyShortFilenameCRLF;

	 int iCopyFilenameNoExt;
	 int iCopyFilenameNoExtSpace;
	 int iCopyFilenameNoExtCRLF;
	 int iCopyParentFolderPath;
	 int iCopyParentFolderPathSpace;
	 int iCopyParentFolderPathCRLF;
	 int iCopyRelativePath;
	 int iCopyRelativePathSpace;
	 int iCopyRelativePathCRLF;
	 int iCopyURLEncodedPath;
	 int iCopyURLEncodedPathSpace;
	 int iCopyURLEncodedPathCRLF;
	 int iCopyURLEncodedRelativePath;
	 int iCopyURLEncodedRelativePathSpace;
	 int iCopyURLEncodedRelativePathCRLF;
	 int iCopyUNCPath;
	 int iCopyUNCPathSpace;
	 int iCopyUNCPathCRLF;
	 int iSettings;

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

	protected:
  //TCHAR m_szFile[MAX_PATH];
  LPCWSTR m_szFile;
  string_list m_lsFiles;
  std::vector<LPCWSTR> m_lsFiles2;
  
public:
  // IShellExtInit

  STDMETHODIMP Initialize(LPCITEMIDLIST, LPDATAOBJECT, HKEY);
public:

	public:
  // IContextMenu

  STDMETHODIMP GetCommandString(UINT_PTR, UINT, UINT*, LPSTR, UINT);
  //STDMETHODIMP GetCommandString(UINT, UINT, UINT*, LPSTR, UINT);
  STDMETHODIMP InvokeCommand(LPCMINVOKECOMMANDINFO);
  STDMETHODIMP QueryContextMenu(HMENU, UINT, UINT, UINT, UINT);

  
  protected:
  HBITMAP     m_hUnlockBmp;
  
};


OBJECT_ENTRY_AUTO(__uuidof(CopyPathToClipboardShellExt), CCopyPathToClipboardShellExt)
