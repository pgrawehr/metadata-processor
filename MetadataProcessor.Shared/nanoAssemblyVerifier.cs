// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace nanoFramework.Tools.MetadataProcessor
{
    public class nanoAssemblyVerifier
    {
        public static void Verify(nanoAssemblyBuilder data)
        {
            var methodsTable = data.TablesContext.MethodReferencesTable;
            foreach (var entry in methodsTable.Items)
            {
                if (!methodsTable.TryGetMethodReferenceId(entry, out ushort id))
                {
                    throw new InvalidOperationException($"The method {entry} is referenced not declared.");
                }

                var r = entry.Resolve();
                if (r == null)
                {
                    throw new InvalidOperationException($"Unable to resolve method {entry}");
                }
            }
        }
    }
}
