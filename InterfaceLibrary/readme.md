<!--TOC-->
- [Overview](#overview)
  - [Interface Implementation Discovery](#interface-implementation-discovery)
  - [Entity Name Extraction](#entity-name-extraction)
  - [Generic IEnumerable Type Extraction](#generic-ienumerable-type-extraction)
  - [ImplementsInterface](#implementsinterface)
  - [ImplementsInterfaces (overload)](#implementsinterfaces-overload)
  - [GetUnimplementedInterfaces](#getunimplementedinterfaces)
<!--/TOC-->

# Overview
The `Helpers` class  provides a collection of utility methods designed to support reflection-based operations, particularly around working with interfaces and generic types. 

See sample usage in the `InterfaceExtensionApp` project in `Program.cs`.

## Interface Implementation Discovery
`GetAllEntities<T>()` scans all loaded assemblies in the current AppDomain and returns a list of concrete types that implement a given interface `T`. It ensures `T` is a valid interface and excludes abstract types or interfaces themselves from the result.

## Entity Name Extraction
`GetAllEntityNames<T>()` builds on `GetAllEntities<T>()` to return just the names of implementing types, rather than their `Type` objects.

## Generic IEnumerable Type Extraction 
`GetGenericIEnumerable(object sender)` inspects an object's implemented interfaces and returns the generic type arguments of all `IEnumerable<T>` interfaces it supports. This is useful for introspection or dynamic type analysis.

## ImplementsInterface
Determines whether a specified class type implements a specified interface type.

## ImplementsInterfaces (overload)
Determines whether a specified class type implements all the specified interface types.

## GetUnimplementedInterfaces
Identifies the interfaces from the provided list that are not implemented by the specified class type.
