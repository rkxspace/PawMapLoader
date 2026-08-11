using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MelonLoader;
using PawMapLoader.Res.PawScript;
using PawMapLoader.Res.PawScript.Json;
using Unity.Collections;

namespace PawMapLoader.Res.GUI.WebServer
{
    public class DebugServer
    {
        private readonly HttpListener _listener  = new HttpListener();
        private readonly string _prefix = "http://localhost:45222/";
        public static Interpreter _interpreter;
        private static List<PawScriptInstruction> _instructions;

        public static void StartWebServer()
        {
            _ = new DebugServer().Start();
            MelonCoroutines.Start(InstructQueue());
            
            IEnumerator InstructQueue()
            {
                if (_instructions.Count > 0)
                {
                    int _inst = 0;
                    _interpreter.Interpret(_instructions[0], ref _inst);
                    _instructions.RemoveAt(0);
                }
                yield return null;
            }
        }

        public DebugServer()
        {
            _listener.Prefixes.Add(_prefix);
        }

        public async Task Start()
        {
            _listener.Start();
            while (true)
            {
                HttpListenerContext context = await _listener.GetContextAsync();
                _ = Task.Run(() =>
                {
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    string resp = string.Empty;
                    if (request.Url.AbsolutePath == "/")
                    {
                        if (request.QueryString.Count > 1)
                        {
                            NameValueCollection query = request.QueryString;
                            resp = request.Url.Query;
                            
                            _instructions.Add(new PawScriptInstruction {Arguments = query.GetValues("arg")?.ToList(), Claw = query["claw"], Delay = int.Parse(query["delay"]), Instruction = query["instruction"]});
                        }
                    }
                    
                    byte[] bffr = Encoding.UTF8.GetBytes(resp);
                    response.ContentType = "text/plain; charset=utf-8";
                    response.ContentLength64 = bffr.LongLength;
                    response.OutputStream.Write(bffr, 0, bffr.Length);
                    response.OutputStream.Close();
                });
            }
        }
    }
}