export function DecryptionView() {
    var form = document.createElement("form");
    form.id = "decryption-form";

    var divText = document.createElement("div");
    var divEncr = document.createElement("div");
    var divKey = document.createElement("div");
    var divIV = document.createElement("div");
    
    // input text
    var inputText = document.createElement("textarea");
    inputText.id = "decr-inputText";
    inputText.classList.add("input-text");
    
    var inputTextLabel = document.createElement("label");
    inputTextLabel.htmlFor = "decr-inputText";
    inputTextLabel.innerText = "Encrypted text";


    // input key
    var inputKey = document.createElement("textarea");
    inputKey.id = "Key";
    inputKey.classList.add("input-text");
    
    var inputKeyLabel = document.createElement("label");
    inputKeyLabel.htmlFor = "Key";
    inputKeyLabel.innerText = "Key";
  
  
    // input IV
    var inputIV = document.createElement("textarea");
    inputIV.id = "IV";
    inputIV.classList.add("input-text");
    
    var inputIVLabel = document.createElement("label");
    inputIVLabel.htmlFor = "IV";
    inputIVLabel.innerText = "IV";


    // button
    var button = document.createElement("button");
    button.innerText = "Decrypt";
    button.type = "button";
    button.id = "btn";
    button.addEventListener("click", async function() {
        var flag = false;
        if (inputText.value == "") {
            inputText.classList.add("invalid");
            flag = true;
        }
        if (inputKey.value == "") {
            inputKey.classList.add("invalid");
            flag = true;
        }
        if (inputIV.value == "") {
            inputIV.classList.add("invalid");
            flag = true;
        }
        if (flag == true) {
            alert("Please fill out all necessary fields");
            return;
        }

        var r = await Decrypt(inputText.value, inputKey.value, inputIV.value);
  
        outputText.value = r;
    })


    // output
    var outputText = document.createElement("textarea");
    outputText.id = "decr-outputText";
    outputText.readOnly = "true";
    outputText.classList.add("input-text");

    var outputTextLabel = document.createElement("label");
    outputTextLabel.htmlFor = "decr-outputText";
    outputTextLabel.innerText = "Text";

    var outputTextCopy = document.createElement("img");
    outputTextCopy.classList.add("clipboard");
    outputTextCopy.classList.add("icon");
    outputTextCopy.src = "img/copy.png";

    outputTextCopy.addEventListener('click', function () {
        var text = inputText;
        text.select();
        document.execCommand('copy');
    })

  
    divText.appendChild(outputTextLabel);
    divText.appendChild(outputText);
    divText.appendChild(outputTextCopy);

    divEncr.appendChild(inputTextLabel);
    divEncr.appendChild(inputText);
    divEncr.appendChild(button);

    divKey.appendChild(inputKeyLabel);
    divKey.appendChild(inputKey);

    divIV.appendChild(inputIVLabel);
    divIV.appendChild(inputIV);


    
    form.appendChild(divEncr);
    form.appendChild(divKey);
    form.appendChild(divIV);
    form.appendChild(divText);

  
    document.body.appendChild(form);
  }
  
  
  
async function Decrypt(inputText, inputKey, inputIV){
    const url = '/decrypt';
    const data = {"Text": inputText,
                  "Key": inputKey,
                  "IV": inputIV}
    const response = await fetch(url, {
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json'
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
        body: JSON.stringify(data)
        });
        var r = await response;
        if (r.status == 200) {
            return r.text();
        }
        else {
            alert("Invalid data");
            return "";
        }
      
  }