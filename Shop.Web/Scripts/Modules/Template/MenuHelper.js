var MenuHelper = {
    //更新菜单
    UpdateMenu: function () {
        var _Shop_MenuVaild = 0;
        $("input[name='Shop_MenuVaild']").each(function() {
            if ($(this).prop("checked")) {
                _Shop_MenuVaild = $(this).val();
            }
        });
        
        var para = {
            Shop_MenuId: $("#Shop_MenuId").val(),
            Shop_MenuName: $("#Shop_MenuName").val(),
            Shop_MenuUrl: $("#Shop_MenuUrl").val(),
            Shop_MenuCode: $("#Shop_MenuCode").val(),
            Shop_ParentId: $("#Shop_ParentId").val(),
            Shop_MenuIcon: $("#Shop_MenuIcon").val(),
            Shop_MenuSort: $("#Shop_MenuSort").val(),
            Shop_MenuVaild: _Shop_MenuVaild,
            Shop_ModuleId: $("#Shop_ModuleId").val()
        };
        $.ajax({
            type: "POST",
            url: "/template/template/UpdateMenu",
            data: { menu: JSON.stringify(para) },
            success: function (data) {
                var json = eval("(" + data + ")");
                if (json.Success) {
                    window.location.href = "/template/template/MenuManage";
                }
            }
        });
    },
    AddMenu: function () {
        var _Shop_MenuVaild = 0;
        $("input[name='Shop_MenuVaild']").each(function () {
            if ($(this).prop("checked")) {
                _Shop_MenuVaild = $(this).val();
            }
        });

        var para = {
            Shop_MenuName: $("#Shop_MenuName").val(),
            Shop_MenuUrl: $("#Shop_MenuUrl").val(),
            Shop_MenuCode: $("#Shop_MenuCode").val(),
            Shop_ParentId: $("#Shop_ParentId").val(),
            Shop_MenuIcon: $("#Shop_MenuIcon").val(),
            Shop_MenuSort: $("#Shop_MenuSort").val(),
            Shop_MenuVaild: _Shop_MenuVaild,
            Shop_ModuleId: $("#Shop_ModuleId").val()
        };
        $.ajax({
            type: "POST",
            url: "/template/template/AddMenu",
            data: { menu: JSON.stringify(para) },
            success: function (data) {
                var json = eval("(" + data + ")");
                if (json.Success) {
                    window.location.href = "/template/template/MenuManage";
                }
            }
        });
    },
    DeleteMenu: function(shop_menuid) {
        $.ajax({
            type: "POST",
            url: "/template/template/DeleteMenu/" + shop_menuid,
            success: function (data) {
                var json = eval("(" + data + ")");
                if (json.Success) {
                    window.location.href = "/template/template/MenuManage";
                }
            }
        });
    }
};