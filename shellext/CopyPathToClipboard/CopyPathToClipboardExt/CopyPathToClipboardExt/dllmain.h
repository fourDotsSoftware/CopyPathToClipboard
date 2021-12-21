// dllmain.h : Declaration of module class.

class CCopyPathToClipboardExtModule : public CAtlDllModuleT< CCopyPathToClipboardExtModule >
{
public :
	DECLARE_LIBID(LIBID_CopyPathToClipboardExtLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_HANDYRESIZEREXT, "{8394A8A8-3820-4121-A4FC-9CCD3780365E}")
};

extern class CCopyPathToClipboardExtModule _AtlModule;
