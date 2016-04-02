﻿#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：RtcToken
* Copyright(c) wisetoro
* CLR 版本: 4.0.30319.17929
* 创 建 人：orman
* 电子邮箱：104913543@qq.com
* 创建日期：2016/4/3 01:40:49
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unirest_net.http;
using unirest_net.request;

namespace RTC.Net
{
    public class RTCToken
    {
        /// <summary>
        /// 获取session_id下令牌列表
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public static HttpResponse<GetTokenResult> GetTokens(string session_id)
        {
            return Rtc.Get("/sessions/" + session_id + "/tokens").asJson<GetTokenResult>();
        }

        /// <summary>
        /// 创建一个令牌
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static HttpResponse<TokenResult> CreateToken(CreateTokenParameter param)
        {
            HttpRequest request = Rtc.Post("/sessions/" + param.session_id + "/tokens");
            foreach (var o in param.ToParameter())
            {
                if (o.Value != null)
                    request.field(o.Key, o.Value.ToString());
            }
            return request.asJson<TokenResult>();
        }

        /// <summary>
        /// 获取session_id下永久令牌列表
        /// </summary>
        /// <returns></returns>
        public static HttpResponse<GetTokenResult> GetSessionsPermanent(string session_id)
        {
            return Rtc.Get("/sessions/" + session_id + "/tokens/permanent").asJson<GetTokenResult>();
        }

        /// <summary>
        /// 获取session_id下临时令牌列表
        /// </summary>
        /// <returns></returns>
        public static HttpResponse<GetTokenResult> GetSessionsNoPermanent(string session_id)
        {
            return Rtc.Get("/sessions/" + session_id + "/tokens/nonpermanent").asJson<GetTokenResult>();
        }

        /// <summary>
        /// 获取一个令牌
        /// </summary>
        /// <param name="token_id"></param>
        /// <returns></returns>
        public static HttpResponse<TokenResult> GetToken(string token_id)
        {
            return Rtc.Get("/tokens/" + token_id).asJson<TokenResult>();
        }

        /// <summary>
        /// 修改一个令牌
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static HttpResponse<TokenResult> ModifyToken(ModifyTokenParameter param)
        {
            HttpRequest request = Rtc.Patch("/tokens/" + param.token_id);
            foreach (var o in param.ToParameter())
            {
                if (o.Value != null)
                    request.field(o.Key, o.Value.ToString());
            }
            return request.asJson<TokenResult>();
        }

        /// <summary>
        /// 删除一个令牌
        /// </summary>
        /// <param name="token_id"></param>
        /// <returns></returns>
        public static HttpResponse<string> DeleteToken(string token_id)
        {
            return Rtc.Delete("/tokens/" + token_id).asString();
        }
    }
}