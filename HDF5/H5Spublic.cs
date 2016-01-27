﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by The HDF Group.                                               *
 * Copyright by the Board of Trustees of the University of Illinois.         *
 * All rights reserved.                                                      *
 *                                                                           *
 * This file is part of HDF5.  The full HDF5 copyright notice, including     *
 * terms governing use, modification, and redistribution, is contained in    *
 * the files COPYING and Copyright.html.  COPYING can be found at the root   *
 * of the source code distribution tree; Copyright.html can be found at the  *
 * root level of an installed copy of the electronic HDF5 document set and   *
 * is linked from the top-level documents page.  It can also be found at     *
 * http://hdfgroup.org/HDF5/doc/Copyright.html.  If you do not have          *
 * access to either file, you may request a copy from help@hdfgroup.org.     *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Runtime.InteropServices;
using System.Security;

using herr_t = System.Int32;
using hid_t = System.Int32;
using hsize_t = System.UInt64;

namespace HDF.PInvoke
{
    public unsafe sealed class H5S
    {
        // Define atomic datatypes
        public const int ALL = 0;
        public const hsize_t UNLIMITED = unchecked((hsize_t)(-1));

        /// <summary>
        /// Define user-level maximum number of dimensions
        /// </summary>
        public const int MAX_RANK = 32;

        /// <summary>
        /// Different types of dataspaces
        /// </summary>
        public enum class_t
        {
            /// <summary>
            /// error [value = -1].
            /// </summary>
            NO_CLASS = -1,
            /// <summary>
            /// scalar variable [value = 0].
            /// </summary>
            SCALAR = 0,
            /// <summary>
            /// simple data space [value = 1].
            /// </summary>
            SIMPLE = 1,
            /// <summary>
            /// null data space [value = 2].
            /// </summary>
            NULL = 2
        }

        [DllImport(Constants.DLLFileName, EntryPoint = "H5Sclose",
            CallingConvention = CallingConvention.Cdecl),
        SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
        public static extern herr_t close(hid_t space_id);

        [DllImport(Constants.DLLFileName, EntryPoint = "H5Screate",
            CallingConvention = CallingConvention.Cdecl),
        SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
        public static extern hid_t create(class_t type);

        [DllImport(Constants.DLLFileName, EntryPoint = "H5Screate_simple",
            CallingConvention = CallingConvention.Cdecl),
        SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
        public static extern hid_t create_simple
            (int rank, hsize_t[] dims, hsize_t[] maxdims);
    }
}