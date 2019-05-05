﻿using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using System.Threading.Tasks;

namespace xnano.Tests.Resources
{
    public enum ResourceType
    {
        Json,
        Misc
    }

    public static class ResourcesProvider
    {
        static readonly string ResourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Resources");

        public static string GetResourceDirectory(ResourceType type)
        {
            return $"{ResourcePath}/{type}";
        }

        public static string GetFilePath(string fileName, ResourceType type)
        {
            return $"{GetResourceDirectory(type)}/{fileName}";
        }

        public static byte[] GetBytes(string fileName, ResourceType type = ResourceType.Misc)
        {
            var file = GetFilePath(fileName, type);
            if (File.Exists(file))
            {
                return File.ReadAllBytes(file);
            }
            throw new FileNotFoundException(file);
        }

        public static async Task<byte[]> GetBytesAsync(string fileName, ResourceType type = ResourceType.Misc)
        {
            var file = GetFilePath(fileName, type);
            if (File.Exists(file))
            {
                return await File.ReadAllBytesAsync(file);
            }
            throw new FileNotFoundException(file);
        }
        public static string GetString(string fileName, ResourceType type = ResourceType.Misc)
        {
            var file = GetFilePath(fileName, type);
            if (File.Exists(file))
            {
                return System.Text.Encoding.UTF8.GetString(
                    File.ReadAllBytes(file)
                );
            }
            throw new FileNotFoundException(file);
        }
    }
}