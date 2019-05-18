

/* -------------------------------------
 * Thực hiện đăng nhập chương trình
 * CreatedBy: NVMANH (28.12.2017)
 * -------------------------------------*/
function btnLogin_onClientClick(sender) {
    var useName = document.getElementById('txtUserName').value,
        passWord = document.getElementById('txtPassword').value;
    if (!useName) {
        alert("Vui lòng nhập tên đăng nhập.");
    } else if (!passWord) {
        alert("Mật khẩu không được để trống.");
    } else {
        window.location.pathname = "/Default.aspx"
    }
}