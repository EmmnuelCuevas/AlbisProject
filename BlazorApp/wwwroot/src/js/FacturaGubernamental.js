window.jsPDF = window.jspdf.jsPDF;
function demoPDF(object) {
    var invoice = JSON.parse(object);
    var details = invoice["Details"];
    var client = invoice["Cliente"];
    console.log(client);

    var doc = new jsPDF();
    var img = new Image()
    var width = doc.internal.pageSize.getWidth();
    var height = doc.internal.pageSize.getHeight();

    img.src = 'src/img/Top-Banner-Factura-Albis.jpg'
    doc.addImage(img, 'jpg', 10, 10, width-25,32 )

    
    // client information 
    doc.setFontSize(13);
    doc.text(20, 60, client["Name"]); //Client Name    
    doc.setFontSize(11);
    doc.text(25, 67, "DIRECCION");   
    doc.text(25, 74, "TELEFONO");
    doc.text(25, 81, "RNC");  
    doc.setFontSize(10);
    doc.text(50, 67, ": " + client["Address"]);//Client Address
    doc.text(50, 74, ": " + client["PhoneNumber"]);//Client Phone Number
    doc.text(50, 81, ": " + client["Rnc"]);  //Client RNC

    // invoice information
    doc.setFontSize(11);
    doc.text(133, 67, "FACTURA No.");
    doc.text(133, 74, "FECHA");
    doc.text(133, 81, "NCF");
    doc.setFontSize(10);
    doc.text(160, 67, ": " +invoice["InvoiceNumber"]);// INVOICE NUMBER
    doc.text(160, 74, ": "+invoice["Fecha"]);// DATE
    doc.text(160, 81, ": " +invoice["Ncf"]);  //NCF ACTUAL +1 NUMBER

    // Invoice table 
        // HEADERS
    doc.setFontSize(10);
    doc.text(25, 95, "CANT.");  
    doc.text(55, 95, "DESCRIPCION");
    doc.text(105, 95, "PRECIO");
    doc.text(140, 95, "ITBIS");
    doc.text(170, 95, "TOTAL");  
    doc.line(22, 99, width-25, 99);

    // Y position for loop

    var yPosition = 8;

    for (var i = 0; i < details.length; i++) {

        // CANT
        doc.text(25, 95 + yPosition, details[i].Quantity.toString())
        // DESCRIPTION
        doc.text(55, 95 + yPosition, details[i].Product["Name"].toString())
        // PRICE
        doc.text(105, 95 + yPosition, details[i].Price.toString())
        // ITBIS
        doc.text(140, 95 + yPosition, (details[i].Total - details[i].SubTotal).toString())
        // TOTAL
        doc.text(170, 95 + yPosition, details[i].Total.toString())
        // reposition Y cordinate
        yPosition = yPosition + 8;    
    }

    yPosition = yPosition + 95 +8;

    // SUMMARY 
    doc.line(22,yPosition, width - 25, yPosition);
    doc.text(width - 65, yPosition + 8, "Sub-total :");
    doc.text(width - 35, yPosition + 8, invoice.SubTotal.toString());

    doc.text(width - 65, yPosition + 14, "ITBIS :");
    doc.text(width - 35, yPosition + 14, invoice.Impuestos.toString());

    doc.text(width - 65, yPosition + 20, "Total-General :");
    doc.text(width - 35, yPosition + 20, "$ "+invoice.Total.toString());

    doc.line(22, yPosition + 25, width - 25, yPosition + 25);


    //Footer
    doc.setFontSize(10);
    doc.text(18, height - 60, "Medi-Express Espinal, S.R.L.")
    doc.text(width - 70, height - 60, "Recibido por")
    doc.text(width - 70, height - 50, "Fecha : __________________")
    doc.setFontSize(12);
    doc.text((width/2)-20,height - 25, "¡ A Tiempo con la Salud !");  

    doc.setFont("times");
    doc.setTextColor(255, 0, 0); //set font color to red    
    doc.setTextColor(165, 0, 0);

    doc.save(client["Name"]+"-"+invoice["Fecha"]+'.pdf'); // Save the PDF with name "katara"...    
}  
function FacturaInformalPDF(object) {

    var invoice = JSON.parse(object);
    var details = invoice["Details"];
    var client = invoice["Cliente"];
    console.log(client);

    var doc = new jsPDF();
    var img = new Image()
    var width = doc.internal.pageSize.getWidth();
    var height = doc.internal.pageSize.getHeight();

    img.src = 'src/img/Top-Banner-Factura-Albis.jpg'
    doc.addImage(img, 'jpg', 10, 10, width - 25, 32)


    // client information 
    doc.setFontSize(13);
    doc.text(20, 60, client["Name"]); //Client Name    
    doc.setFontSize(11);
    doc.text(25, 67, "DIRECCION");
    doc.text(25, 74, "TELEFONO");
    doc.text(25, 81, "RNC");
    doc.setFontSize(10);
    doc.text(50, 67, ": " + client["Address"]);//Client Address
    doc.text(50, 74, ": " + client["PhoneNumber"]);//Client Phone Number
    doc.text(50, 81, ": " );  //Client RNC

    // invoice information
    doc.setFontSize(11);
    doc.text(133, 67, "FACTURA No.");
    doc.text(133, 74, "FECHA");
    doc.text(133, 81, "");
    doc.setFontSize(10);
    doc.text(160, 67, ": " +invoice["InvoiceNumber"]);// INVOICE NUMBER
    doc.text(160, 74, ": " + invoice["Fecha"]);// DATE
    doc.text(160, 81, ": " );  //NCF ACTUAL +1 NUMBER

    // Invoice table 
    // HEADERS
    doc.setFontSize(10);
    doc.text(25, 95, "CANT.");
    doc.text(55, 95, "DESCRIPCION");
    doc.text(105, 95, "PRECIO");
    doc.text(140, 95, "ITBIS");
    doc.text(170, 95, "TOTAL");
    doc.line(22, 99, width - 25, 99);

    // Y position for loop

    var yPosition = 8;

    for (var i = 0; i < details.length; i++) {

        // CANT
        doc.text(25, 95 + yPosition, details[i].Quantity.toString())
        // DESCRIPTION
        doc.text(55, 95 + yPosition, details[i].Product["Name"].toString())
        // PRICE
        doc.text(105, 95 + yPosition, (details[i].Price + ((details[i].Total - details[i].SubTotal) / details[i].Quantity)) .toString())
        // ITBIS
        doc.text(140, 95 + yPosition, "")
        // TOTAL
        doc.text(170, 95 + yPosition, details[i].Total.toString())
        // reposition Y cordinate
        yPosition = yPosition + 8;
    }

    yPosition = yPosition + 95 + 8;

    // SUMMARY 
    doc.line(22, yPosition, width - 25, yPosition);
    doc.text(width - 65, yPosition + 8, "Sub-total :");
    doc.text(width - 35, yPosition + 8, invoice.Total.toString());

    doc.text(width - 65, yPosition + 14, "ITBIS :");
    doc.text(width - 35, yPosition + 14, "");

    doc.text(width - 65, yPosition + 20, "Total-General :");
    doc.text(width - 35, yPosition + 20, "$ " + invoice.Total.toString());

    doc.line(22, yPosition + 25, width - 25, yPosition + 25);


    //Footer
    doc.setFontSize(10);
    doc.text(18, height - 60, "Medi-Express Espinal, S.R.L.")
    doc.text(width - 70, height - 60, "Recibido por")
    doc.text(width - 70, height - 50, "Fecha : __________________")
    doc.setFontSize(12);
    doc.text((width / 2) - 20, height - 25, "¡ A Tiempo con la Salud !");

    doc.setFont("times");
    doc.setTextColor(255, 0, 0); //set font color to red    
    doc.setTextColor(165, 0, 0);

    doc.save(client["Name"] + "-" + invoice["Fecha"] + '.pdf'); // Save the PDF with name "katara"...    
}  
function CotizacionPDF(object) {

    var invoice = JSON.parse(object);
    var details = invoice["Details"];
    var client = invoice["Cliente"];

    var doc = new jsPDF();
    var img = new Image()
    var width = doc.internal.pageSize.getWidth();
    var height = doc.internal.pageSize.getHeight();

    img.src = 'src/img/Top-Banner-Factura-Albis.jpg'
    doc.addImage(img, 'jpg', 10, 10, width - 25, 25)

    // client information 
    doc.setFontSize(13);
    doc.text((width / 2) - 20,45,"COTIZACIÓN")
    doc.text(20, 60, client["Name"]); //Client Name    
    doc.setFontSize(11);
    doc.text(25, 67, "DIRECCION");
    doc.text(25, 74, "TELEFONO");
    doc.text(25, 81, "RNC");
    doc.setFontSize(10);
    doc.text(50, 67, ": " + client["Address"]);//Client Address
    doc.text(50, 74, ": " + client["PhoneNumber"]);//Client Phone Number
    doc.text(50, 81, ": " + client["Rnc"]);  //Client RNC

    // invoice information
    doc.setFontSize(11);
    doc.text(133, 67, "No.");
    doc.text(133, 74, "FECHA");
    doc.setFontSize(10);
    doc.text(160, 67, ": 0849");// INVOICE NUMBER
    doc.text(160, 74, ": " + invoice["Fecha"]);// DATE

    // Invoice table 
    // HEADERS
    doc.setFontSize(10);
    doc.text(25, 95, "CANT.");
    doc.text(55, 95, "DESCRIPCION");
    doc.text(105, 95, "PRECIO");
    doc.text(140, 95, "ITBIS");
    doc.text(170, 95, "TOTAL");
    doc.line(22, 99, width - 25, 99);

    // Y position for loop

    var yPosition = 8;

    for (var i = 0; i < details.length; i++) {

        // CANT
        doc.text(25, 95 + yPosition, details[i].Quantity.toString())
        // DESCRIPTION
        doc.text(55, 95 + yPosition, details[i].Product["Name"].toString())
        // PRICE
        doc.text(105, 95 + yPosition, details[i].Price.toString())
        // ITBIS
        doc.text(140, 95 + yPosition, (details[i].Total - details[i].SubTotal).toString())
        // TOTAL
        doc.text(170, 95 + yPosition, details[i].Total.toString())
        // reposition Y cordinate
        yPosition = yPosition + 8;
    }

    yPosition = yPosition + 95 + 8;

    // SUMMARY 
    doc.line(22, yPosition, width - 25, yPosition);
    doc.text(width - 65, yPosition + 8, "Sub-total :");
    doc.text(width - 35, yPosition + 8, invoice.SubTotal.toString());

    doc.text(width - 65, yPosition + 14, "ITBIS :");
    doc.text(width - 35, yPosition + 14, invoice.Impuestos.toString());

    doc.text(width - 65, yPosition + 20, "Total-General :");
    doc.text(width - 35, yPosition + 20, "$ " + invoice.Total.toString());

    doc.line(22, yPosition + 25, width - 25, yPosition + 25);


    //Footer
    doc.setFontSize(10);
    doc.text(18, height - 60, "Medi-Express Espinal, S.R.L.")
    doc.text(width - 70, height - 60, "Recibido por")
    doc.text(width - 70, height - 50, "Fecha : __________________")
    doc.setFontSize(12);
    doc.text((width / 2) - 20, height - 25, "¡ A Tiempo con la Salud !");

    doc.setFont("times");
    doc.setTextColor(255, 0, 0); //set font color to red    
    doc.setTextColor(165, 0, 0);

    doc.save("COTIZACION-"+client["Name"] + "-" + invoice["Fecha"] + '.pdf'); // Save the PDF with name "katara"...    

}
function ConducePDF(object) {

    var invoice = JSON.parse(object);
    var details = invoice["Details"];
    var client = invoice["Cliente"];

    var doc = new jsPDF();
    var img = new Image()
    var width = doc.internal.pageSize.getWidth();
    var height = doc.internal.pageSize.getHeight();

    img.src = 'src/img/Top-Banner-Factura-Albis.jpg'
    doc.addImage(img, 'jpg', 10, 10, width - 25, 25)

    // client information 
    doc.setFontSize(13);
    doc.text((width / 2) - 20, 45, "CONDUCE")
    doc.text(20, 60, client["Name"]); //Client Name    
    doc.setFontSize(11);
    doc.text(25, 67, "DIRECCION");
    doc.text(25, 74, "TELEFONO");
    doc.text(25, 81, "RNC");
    doc.setFontSize(10);
    doc.text(50, 67, ": " + client["Address"]);//Client Address
    doc.text(50, 74, ": " + client["PhoneNumber"]);//Client Phone Number
    doc.text(50, 81, ": " + client["Rnc"]);  //Client RNC

    // invoice information
    doc.setFontSize(11);
    doc.text(133, 67, "No.");
    doc.text(133, 74, "FECHA");
    doc.setFontSize(10);
    doc.text(160, 67, ": 0849");// INVOICE NUMBER
    doc.text(160, 74, ": " + invoice["Fecha"]);// DATE

    // Invoice table 
    // HEADERS
    doc.setFontSize(10);
    doc.text(25, 95, "CANT.");
    doc.text(55, 95, "DESCRIPCION");
    
    doc.line(22, 99, width - 25, 99);

    // Y position for loop

    var yPosition = 8;

    for (var i = 0; i < details.length; i++) {

        // CANT
        doc.text(25, 95 + yPosition, details[i].Quantity.toString())
        // DESCRIPTION
        doc.text(55, 95 + yPosition, details[i].Product["Name"].toString())
        // PRICE
        yPosition = yPosition + 8;
    }

    yPosition = yPosition + 95 + 8;

    // SUMMARY 
    doc.line(22, yPosition + 25, width - 25, yPosition + 25);

    //Footer
    doc.setFontSize(10);
    doc.text(18, height - 60, "Medi-Express Espinal, S.R.L.")
    doc.text(width - 70, height - 60, "Recibido por")
    doc.text(width - 70, height - 50, "Fecha : __________________")
    doc.setFontSize(12);
    doc.text((width / 2) - 20, height - 25, "¡ A Tiempo con la Salud !");

    doc.setFont("times");
    doc.setTextColor(255, 0, 0); //set font color to red    
    doc.setTextColor(165, 0, 0);

    doc.save("CONDUCE -" + client["Name"] + "-" + invoice["Fecha"] + '.pdf'); // Save the PDF with name "katara"...    

}