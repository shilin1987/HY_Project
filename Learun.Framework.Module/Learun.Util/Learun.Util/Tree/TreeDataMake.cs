﻿using System.Collections.Generic;

namespace Learun.Util
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.07
    /// 描 述：树结构数据
    /// </summary>
    public static class TreeDataMake
    {
        /// <summary>
        /// 树形数据转化
        /// </summary>
        /// <param name="list">数据</param>
        /// <returns></returns>
        public static List<TreeModel> ToTree(this List<TreeModel> list,string parentId = "")
        {
            //孩子节点
            Dictionary<string, List<TreeModel>> childrenMap = new Dictionary<string, List<TreeModel>>();
            //父节点
            Dictionary<string, TreeModel> parentMap = new Dictionary<string, TreeModel>();

            List<TreeModel> res = new List<TreeModel>();

            //首先按照
            foreach (var node in list)
            {
                node.hasChildren = false;
                node.complete = true;
                // 注册子节点映射表
                if (!childrenMap.ContainsKey(node.parentId))
                {
                    childrenMap.Add(node.parentId, new List<TreeModel>());
                }
                else if (parentMap.ContainsKey(node.parentId))
                {
                    parentMap[node.parentId].hasChildren = true;
                }
                childrenMap[node.parentId].Add(node);
                // 注册父节点映射节点表
                parentMap.Add(node.id, node);

                // 查找自己的子节点
                if (!childrenMap.ContainsKey(node.id))
                {
                    childrenMap.Add(node.id, new List<TreeModel>());
                }
                else
                {
                    node.hasChildren = true;
                }
                node.ChildNodes = childrenMap[node.id];
            }

            if (string.IsNullOrEmpty(parentId))
            {
                // 获取祖先数据列表
                foreach (var item in childrenMap)
                {
                    if (!parentMap.ContainsKey(item.Key))
                    {
                        res.AddRange(item.Value);
                    }
                    else
                    {
                        res.AddRange(item.Value);
                    }
                }
            }
            else {
                if (childrenMap.ContainsKey(parentId))
                {
                    return childrenMap[parentId];
                }
                else {
                    return new List<TreeModel>();
                }
            }
            return res;
        }

        /// <summary>
        /// 树形数据转化
        /// </summary>
        /// <param name="list">数据</param>
        /// <returns></returns>
        public static List<TreeModelEx<T>> ToTree<T>(this List<TreeModelEx<T>> list) where T : class
        {
            Dictionary<string, List<TreeModelEx<T>>> childrenMap = new Dictionary<string, List<TreeModelEx<T>>>();
            Dictionary<string, TreeModelEx<T>> parentMap = new Dictionary<string, TreeModelEx<T>>();
            List<TreeModelEx<T>> res = new List<TreeModelEx<T>>();

            //首先按照
            foreach (var node in list)
            {
                // 注册子节点映射表
                if (!childrenMap.ContainsKey(node.parentId))
                {
                    childrenMap.Add(node.parentId, new List<TreeModelEx<T>>());
                }
                childrenMap[node.parentId].Add(node);
                // 注册父节点映射节点表
                parentMap.Add(node.id, node);

                // 查找自己的子节点
                if (!childrenMap.ContainsKey(node.id))
                {
                    childrenMap.Add(node.id, new List<TreeModelEx<T>>());
                }
                node.ChildNodes = childrenMap[node.id];
            }
            // 获取祖先数据列表
            foreach (var item in childrenMap)
            {
                if (!parentMap.ContainsKey(item.Key))
                {
                    res.AddRange(item.Value);
                }
            }
            return res;
        }

        /// <summary>
        /// 树形数据转化
        /// </summary>
        /// <param name="list">数据</param>
        /// <returns></returns>
        public static List<TreeMenu> ToMenuTree(this List<TreeMenu> list, string parentId = "")
        {
            Dictionary<string, List<TreeMenu>> childrenMap = new Dictionary<string, List<TreeMenu>>();
            Dictionary<string, TreeMenu> parentMap = new Dictionary<string, TreeMenu>();
            List<TreeMenu> res = new List<TreeMenu>();

            //首先按照
            foreach (var node in list)
            {
                node.hasChildren = false;
                node.complete = true;
                // 注册子节点映射表
                if (!childrenMap.ContainsKey(node.parentId))
                {
                    childrenMap.Add(node.parentId, new List<TreeMenu>());
                }
                else if (parentMap.ContainsKey(node.parentId))
                {
                    parentMap[node.parentId].hasChildren = true;
                }
                childrenMap[node.parentId].Add(node);
                // 注册父节点映射节点表
                parentMap.Add(node.id, node);

                // 查找自己的子节点
                if (!childrenMap.ContainsKey(node.id))
                {
                    childrenMap.Add(node.id, new List<TreeMenu>());
                }
                else
                {
                    node.hasChildren = true;
                }
                node.ChildNodes = childrenMap[node.id];
            }

            if (string.IsNullOrEmpty(parentId))
            {
                // 获取祖先数据列表
                foreach (var item in childrenMap)
                {
                    if (!parentMap.ContainsKey(item.Key))
                    {
                        res.AddRange(item.Value);
                    }
                }
            }
            else
            {
                if (childrenMap.ContainsKey(parentId))
                {
                    return childrenMap[parentId];
                }
                else
                {
                    return new List<TreeMenu>();
                }
            }
            return res;
        }
    }
}
