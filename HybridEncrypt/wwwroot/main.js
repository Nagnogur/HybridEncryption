import {EncryptionView} from "./encryptionView.js"
import {DecryptionView} from "./decryptionView.js"

var cur = document.querySelector('input[name="operation"]:checked').value;

var rad = document.getElementsByName("operation");
for (var i = 0; i < rad.length; i++) {
    rad[i].addEventListener('change', function() {
        cur = this.value;
        this.checked = true;
        selectView();
    });
}

selectView();

function selectView() {
    if (cur == "encryption") {
    DeleteForm();
    EncryptionView();
  }
    else if (cur == "decryption") {
    DeleteForm();
    DecryptionView();
  }
}

function DeleteForm() {
  var form = document.getElementsByTagName("form")[0];
  if (form == null) {
    return;
  }
  else {
    document.body.removeChild(form);
  }
}

