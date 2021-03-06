﻿using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.Localization;

namespace DM.UBP.Domain.Service.SysManage.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class UbpAuthorizationProvider : AuthorizationProvider
    {
        public const string _rootPermission = "Ubp";

        private readonly bool _isMultiTenancyEnabled;

        //private IModuleManager _moduleManager;


        public UbpAuthorizationProvider(bool isMultiTenancyEnabled
            //,IModuleManagers moduleManagers
            )
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
            //_moduleManagers = moduleManagers;
        }

        public UbpAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        [UnitOfWork]
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //if (_moduleManager == null)
            //{
            //    _moduleManager = IocManager.Instance.Resolve<ModuleManager>();
            //}

            //var rootPermission = context.GetPermissionOrNull(_rootPermission) ?? context.CreatePermission(_rootPermission, L(_rootPermission));
            //rootPermission.CreateChildPermission("Dashboard", L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);
            //List<Module> childModuleList = _moduleManager.GetModulesAsync(null).Result;
            //CreateChildPermission(rootPermission, childModuleList);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, UbpConsts.LocalizationSourceName);
        }

        /// <summary>
        /// 权限表（abppermissions）的保存规则（Name字段）：
        ///     模块：M_模块ID
        ///     模块操作码：O_操作码ID
        ///     列过滤器：C_列过滤器ID
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="moduleList"></param>
        //private void CreateChildPermission(Permission permission, List<Module> moduleList)
        //{
        //    //TODO：对多租户的支持。
        //    foreach (Module module in moduleList)
        //    {
        //        Permission perm = null;

        //        //如果当前模块支持多租户，则直接取module.MultiTenancySide；
        //        //如果当前模块不支持多租户，则multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant
        //        if (module.IsMultiTenancyEnabled)
        //            perm = permission.CreateChildPermission("M_" + module.Id.ToString(), L(module.ModuleCode), multiTenancySides: module.MultiTenancySide);
        //        else
        //            perm = permission.CreateChildPermission("M_" + module.Id.ToString(), L(module.ModuleCode), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);

        //        if (!module.IsLast)
        //        {
        //            List<Module> childModuleList = _moduleManager.GetModulesAsync(module.Id).Result;
        //            CreateChildPermission(perm, childModuleList);
        //        }
        //        else  //如果是末级模块（菜单），则加载模块操作权限
        //        {
        //            List<ModuleOperate> moduleOperateList = _moduleManager.GetModuleOperatesAsync(module.Id).Result;
        //            foreach(ModuleOperate opt in moduleOperateList)
        //            {
        //                perm.CreateChildPermission("O_" + opt.Id.ToString(), L(opt.OperateCode), multiTenancySides: module.MultiTenancySide);
        //            }
        //        }
        //    }
        //}
    }
}
