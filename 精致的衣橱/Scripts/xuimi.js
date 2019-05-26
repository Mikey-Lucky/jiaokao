/// <reference path="E:\工作室\下\精致的衣橱\精致的衣橱\utf8-asp/third-party/xiumi-ue-dialog-v5.html" />
/// <reference path="../utf8-asp/third-party/xss.min.js" />
/// <reference path="E:\工作室\下\精致的衣橱\精致的衣橱\utf8-asp/third-party/xiumi-ue-dialog-v5.html" />
/// <reference path="E:\工作室\下\精致的衣橱\精致的衣橱\utf8-asp/third-party/xiumi-ue-dialog-v5.html" />
/**
 * Created by shunchen_yang on 16/10/25.
 */
UE.registerUI('dialog', function (editor, uiName) {
    var btn = new UE.ui.Button({
        name: 'xiumi-connect',
        title: 'keke',
        onclick: function () {
            var dialog = new UE.ui.Dialog({
                iframeUrl: '../utf8-asp/third-party/xiumi-ue-dialog-v5.html',
                editor: editor,
                name: 'xiumi-connect',
                title: "xiumi",
                cssRules: "width: " + (window.innerWidth - 60) + "px;" + "height: " + (window.innerHeight - 60) + "px;",
            });
            dialog.render();
            dialog.open();
        }
    });

    return btn;
});