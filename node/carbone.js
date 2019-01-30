const carbone = require('carbone');

module.exports = {
  create: function (callback, dataIn, options) {
    var data = JSON.parse(dataIn);
    carbone.render('./node_modules/carbone/examples/simple.odt', data, function (err, result) {
      if (err) {
        callback(err, null);
      }
      callback(null, result);
    });
  }
};
