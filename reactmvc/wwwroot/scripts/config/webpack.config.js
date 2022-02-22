const path = require("path");
 
module.exports = {
    entry: {
        index: "./wwwroot/scripts/src/index.js"
    },
    output: {
        path: path.resolve(__dirname, "../dist"),
        filename: "index.js"
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /(node_modules|bower_components)/,
                loader: 'babel-loader',
                options: { presets: [ '@babel/preset-react'] },
              }
        ]
    }
}
