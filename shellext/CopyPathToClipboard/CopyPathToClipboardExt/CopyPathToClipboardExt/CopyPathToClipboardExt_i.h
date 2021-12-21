

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Tue Jan 19 05:14:07 2038
 */
/* Compiler settings for CopyPathToClipboardExt.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.01.0622 
    protocol : all , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 500
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __CopyPathToClipboardExt_i_h__
#define __CopyPathToClipboardExt_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ICopyPathToClipboardShellExt_FWD_DEFINED__
#define __ICopyPathToClipboardShellExt_FWD_DEFINED__
typedef interface ICopyPathToClipboardShellExt ICopyPathToClipboardShellExt;

#endif 	/* __ICopyPathToClipboardShellExt_FWD_DEFINED__ */


#ifndef __CopyPathToClipboardShellExt_FWD_DEFINED__
#define __CopyPathToClipboardShellExt_FWD_DEFINED__

#ifdef __cplusplus
typedef class CopyPathToClipboardShellExt CopyPathToClipboardShellExt;
#else
typedef struct CopyPathToClipboardShellExt CopyPathToClipboardShellExt;
#endif /* __cplusplus */

#endif 	/* __CopyPathToClipboardShellExt_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __ICopyPathToClipboardShellExt_INTERFACE_DEFINED__
#define __ICopyPathToClipboardShellExt_INTERFACE_DEFINED__

/* interface ICopyPathToClipboardShellExt */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_ICopyPathToClipboardShellExt;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("39809273-18E9-4058-86C6-49BF635BD36E")
    ICopyPathToClipboardShellExt : public IUnknown
    {
    public:
    };
    
    
#else 	/* C style interface */

    typedef struct ICopyPathToClipboardShellExtVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICopyPathToClipboardShellExt * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICopyPathToClipboardShellExt * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICopyPathToClipboardShellExt * This);
        
        END_INTERFACE
    } ICopyPathToClipboardShellExtVtbl;

    interface ICopyPathToClipboardShellExt
    {
        CONST_VTBL struct ICopyPathToClipboardShellExtVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICopyPathToClipboardShellExt_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICopyPathToClipboardShellExt_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICopyPathToClipboardShellExt_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICopyPathToClipboardShellExt_INTERFACE_DEFINED__ */



#ifndef __CopyPathToClipboardExtLib_LIBRARY_DEFINED__
#define __CopyPathToClipboardExtLib_LIBRARY_DEFINED__

/* library CopyPathToClipboardExtLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_CopyPathToClipboardExtLib;

EXTERN_C const CLSID CLSID_CopyPathToClipboardShellExt;

#ifdef __cplusplus

class DECLSPEC_UUID("E6EB91D0-CB9A-4371-91C3-99D726393B92")
CopyPathToClipboardShellExt;
#endif
#endif /* __CopyPathToClipboardExtLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


