const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "https://localhost:7262",
    secure: false
  },
  {
    context: [
      "/calculocdb",
    ],
    target: "https://localhost:7262",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
