export function EncryptionView() {
    var form = document.createElement("form");
    form.id = "encryption-form";

    var divText = document.createElement("div");
    var divEncr = document.createElement("div");
    var divKey = document.createElement("div");
    var divIV = document.createElement("div");

  
    // input
    var inputText = document.createElement("textarea");
    inputText.id = "encr-input";
    inputText.classList.add("input-text");
    inputText.placeholder = "Write text to encrypt";
  
    inputText.oninput = function() {
      if (inputText.value == "") {
        inputText.classList.add("invalid");
      }
      else {
        inputText.classList.remove("invalid");
      }
    }
  
    var inputLabel = document.createElement("label");
    inputLabel.htmlFor = "encr-input";
    inputLabel.innerText = "Input";
  
  
    // button
    var button = document.createElement("button");
    button.id = "btn";
    button.innerText = "Encrypt";
    button.type = "button";
    button.addEventListener("click", async function() {
      var input = document.getElementById("encr-input").value;
      if (input == "") {
          inputText.classList.add("invalid");
          alert("Please fill out input field");
        return;
      }
        var r = await Encrypt(input);
  
        outputText.value = r.text;
        outputKey.value = r.key;
        outputIV.value = r.iv;
    })
  
    // text
    var outputText = document.createElement("textarea");
    outputText.id = "encr-outputText";
    outputText.classList.add("input-text");
    outputText.readOnly = "true";
    
    var outputTextLabel = document.createElement("label");
    outputTextLabel.htmlFor = "encr-outputText";
    outputTextLabel.innerText = "Text";

    var outputTextCopy = document.createElement("img");
    outputTextCopy.classList.add("clipboard");
    outputTextCopy.classList.add("icon");
    outputTextCopy.src = "img/copy.png";

    outputTextCopy.addEventListener('click', function () {
        var text = outputText;
        text.select();
        document.execCommand('copy');
    })
  
  
    // key
    var outputKey = document.createElement("textarea");
    outputKey.id = "Key";
    outputKey.classList.add("input-text");
    outputKey.readOnly = "true";
    
    var outputKeyLabel = document.createElement("label");
    outputKeyLabel.htmlFor = "Key";
    outputKeyLabel.innerText = "Key";

    var outputKeyCopy = document.createElement("img");
    outputKeyCopy.classList.add("clipboard");
    outputKeyCopy.classList.add("icon");
    outputKeyCopy.src = "img/copy.png";

    outputKeyCopy.addEventListener('click', function () {
        var text = outputKey;
        text.select();
        document.execCommand('copy');
    })
  
  
    // IV
    var outputIV = document.createElement("textarea");
    outputIV.id = "IV";
    outputIV.classList.add("input-text");
    outputIV.readOnly = "true";
    
    var outputIVLabel = document.createElement("label");
    outputIVLabel.htmlFor = "IV";
    outputIVLabel.innerText = "IV";

    var outputIVCopy = document.createElement("img");
    outputIVCopy.classList.add("clipboard");
    outputIVCopy.classList.add("icon");
    outputIVCopy.src = "img/copy.png";

    outputIVCopy.addEventListener('click', function () {
        var text = outputIV;
        text.select();
        document.execCommand('copy');
    })



    divText.appendChild(inputLabel);
    divText.appendChild(inputText);
  
    divText.appendChild(button);
  
    divEncr.appendChild(outputTextLabel);
    divEncr.appendChild(outputText);
    divEncr.appendChild(outputTextCopy);
  
    divKey.appendChild(outputKeyLabel);
    divKey.appendChild(outputKey);
    divKey.appendChild(outputKeyCopy);
  
    divIV.appendChild(outputIVLabel);
    divIV.appendChild(outputIV);
    divIV.appendChild(outputIVCopy);


    form.appendChild(divText);
    form.appendChild(divEncr);
    form.appendChild(divKey);
    form.appendChild(divIV);
  
    document.body.appendChild(form);
  }
  
  
  
  async function Encrypt(input){
    const url = '/encrypt';
    const data = {"Text":input}
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
      var r = await response.json();
      return r;
  }