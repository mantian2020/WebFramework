var ModuleHelper = {
    //添加模块
    AddShopModules: function() {
        var _shop_modules_isstart = 0;
        $("input[name='Shop_Modules_IsStart']").each(function () {
            if ($(this).prop("checked")) {
                _shop_modules_isstart = $(this).val();
            }
        });

        var _shop_modules_isvalid = 0;
        $("input[name='Shop_Modules_IsValid']").each(function () {
            if ($(this).prop("checked")) {
                _shop_modules_isvalid = $(this).val();
            }
        });

        var para = {
            Shop_Modules_Name: $("#Shop_Modules_Name").val(),
            Shop_Modules_Description: $("#Shop_Modules_Description").val(),
            Shop_Modules_IsStart: _shop_modules_isstart,
            Shop_Modules_IsValid: _shop_modules_isvalid,
            Shop_Modules_Sort: $("#Shop_Modules_Sort").val()
        };
        $.ajax({
            type: "POST",
            url: "/Module/Module/AddShopModules",
            data: { module: JSON.stringify(para) },
            success: function (data) {
                var json = eval("(" + data + ")");
                if (json.Success) {
                    window.location.href = "/Module/Module/ModuleManage";
                }
            }
        });
    },
    UpdateShopModules: function () {
        var _shop_modules_isstart = 0;
        $("input[name='Shop_Modules_IsStart']").each(function () {
            if ($(this).prop("checked")) {
                _shop_modules_isstart = $(this).val();
            }
        });

        var _shop_modules_isvalid = 0;
        $("input[name='Shop_Modules_IsValid']").each(function () {
            if ($(this).prop("checked")) {
                _shop_modules_isvalid = $(this).val();
            }
        });

        var para = {
            Shop_Modules_Id:$("#Shop_Modules_Id").val(),
            Shop_Modules_Name: $("#Shop_Modules_Name").val(),
            Shop_Modules_Description: $("#Shop_Modules_Description").val(),
            Shop_Modules_IsStart: _shop_modules_isstart,
            Shop_Modules_IsValid: _shop_modules_isvalid,
            Shop_Modules_Sort: $("#Shop_Modules_Sort").val()
        };
        $.ajax({
            type: "POST",
            url: "/Module/Module/UpdateShopModules",
            data: { module: JSON.stringify(para) },
            success: function (data) {
                var json = eval("(" + data + ")");
                if (json.Success) {
                    window.location.href = "/Module/Module/ModuleManage";
                }
            }
        });
    },
    DeleteShopModules: function (moduleId) {
        $.ajax({
            type: "POST",
            url: "/Module/Module/DeleteShopModules/" + moduleId,
            success: function (data) {
                var json = eval("(" + data + ")");
                if (json.Success) {
                    window.location.href = "/Module/Module/ModuleManage";
                }
            }
        });
    }
};