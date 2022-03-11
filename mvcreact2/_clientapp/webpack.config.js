"use strict";
const webpack = require("webpack");
const path = require("path");

module.exports = {
  mode: "development",
  watch: false,
  entry: "./js/index.tsx",
  devtool: "source-map",
  output: {
    filename: "../dist/reactapp.js",
  },
  resolve: { extensions: [".ts", ".tsx", ".js", ".css"] },
  module: {
    rules: [
      {
        test: /\.tsx$/,
        exclude: /node_modules/,
        use: "ts-loader",
      },
      {
        test: /\.css$/,
        use: ["style-loader", "css-loader"],
      },
      { test: /\.svg(\?.+)?$/, 
        use: "file-loader" },
    ],
  },
};
