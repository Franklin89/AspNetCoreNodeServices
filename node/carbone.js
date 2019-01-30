const fs = require('fs');
const carbone = require('carbone');


module.exports = {
  create: function (callback, dataIn, options) {
    var data = JSON.parse(dataIn);
    carbone.render('./node_modules/carbone/examples/simple.odt', data, function (err, result) {
      if (err) {
        console.log(err);
        callback(err, null);
      }
      // write the result
      fs.writeFileSync('result.odt', result);
      callback(null, data);
    });
  }
};

// module.exports = function (callback, dataIn) {

// var data = {
//   firstname : 'John',
//   lastname : 'Doe'
// };


// !!! Requires LibreOffice to work !!!
// var options = {
//   convertTo : 'txt' //can be docx, txt, ...
// };

// };