﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace TunnelVisionLabs.ReferenceAssemblyAnnotator
{
    using System;
    using System.Runtime.CompilerServices;
    using Mono.Cecil;

    internal class WellKnownTypes
    {
        public WellKnownTypes(ModuleDefinition module)
        {
            Module = module;

            SystemAttribute = ResolveWellKnownType(module, typeof(Attribute));
            SystemAttributeTargets = ResolveWellKnownType(module, typeof(AttributeTargets));
            SystemAttributeUsageAttribute = ResolveWellKnownType(module, typeof(AttributeUsageAttribute));
            SystemRuntimeCompilerServicesCompilerGeneratedAttribute = ResolveWellKnownType(module, typeof(CompilerGeneratedAttribute));
        }

        public ModuleDefinition Module { get; }

        public TypeSystem TypeSystem => Module.TypeSystem;

        public TypeReference SystemAttribute { get; }

        public TypeReference SystemAttributeTargets { get; }

        public TypeReference SystemAttributeUsageAttribute { get; }

        public TypeReference SystemRuntimeCompilerServicesCompilerGeneratedAttribute { get; }

        private static TypeDefinition ResolveWellKnownType(ModuleDefinition module, Type type)
        {
            return module.TypeSystem.Object.Resolve().Module.GetType(type.FullName);
        }
    }
}
