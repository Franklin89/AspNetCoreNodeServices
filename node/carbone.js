// const fs = require('fs');
const carbone = require('carbone');

module.exports = {
  create: function (callback, dataIn, options) {
    var data = JSON.parse(dataIn);
    carbone.render('./node_modules/carbone/examples/simple.odt', data, function (err, result) {
      if (err) {
        console.log(err);
        callback(err, null);
      }
      // write the result to the filesystem
      // fs.writeFileSync('result.odt', result);
      
      // return the result
      callback(null, result);
    });
  }
};
