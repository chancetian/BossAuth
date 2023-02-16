<template>
  <div class="login">
    <el-form ref="loginForm" :model="loginForm" :rules="loginRules" class="login-form">
      <h3 class="title">Boss后台权限管理系统admin/admin123</h3>
      <el-form-item prop="username">
        <el-input
          v-model="loginForm.username"
          type="text"
          auto-complete="off"
          placeholder="账号"
        >
          <svg-icon slot="prefix" icon-class="user" class="el-input__icon input-icon" />
        </el-input>
      </el-form-item>
      <el-form-item prop="password">
        <el-input
          v-model="loginForm.password"
          type="password"
          auto-complete="off"
          placeholder="密码"
          @keyup.enter.native="handleLogin"
        >
          <svg-icon slot="prefix" icon-class="password" class="el-input__icon input-icon" />
        </el-input>
      </el-form-item>
      <el-form-item prop="code" v-if="captchaEnabled">
        <el-input
          v-model="loginForm.code"
          auto-complete="off"
          placeholder="验证码"
          style="width: 63%"
          @keyup.enter.native="handleLogin"
        >
          <svg-icon slot="prefix" icon-class="validCode" class="el-input__icon input-icon" />
        </el-input>
        <div class="login-code">
          <img :src="codeUrl" @click="getCode" class="login-code-img"/>
        </div>
      </el-form-item>
      <el-checkbox v-model="loginForm.rememberMe" style="margin:0px 0px 25px 0px;">记住密码</el-checkbox>
      <el-form-item style="width:100%;">
        <el-button
          :loading="loading"
          size="medium"
          type="primary"
          style="width:100%;"
          @click.native.prevent="handleLogin"
        >
          <span v-if="!loading">登 录</span>
          <span v-else>登 录 中...</span>
        </el-button>
        <div style="float: right;" v-if="register">
          <router-link class="link-type" :to="'/register'">立即注册</router-link>
        </div>
      </el-form-item>
    </el-form>
    <!--  底部  -->
    <div class="el-login-footer">
      <span>Copyright © 2022-2022 BossAuth All Rights Reserved.</span>
    </div>
  </div>
</template>

<script>
import { getCodeImg } from "@/api/login";
import Cookies from "js-cookie";
import { encrypt, decrypt } from '@/utils/jsencrypt'

export default {
  name: "Login",
  data() {
    return {
      codeUrl: "",
      loginForm: {
        username: "",
        password: "",
        rememberMe: false,
        code: "",
        uuid: ""
      },
      loginRules: {
        username: [
          { required: true, trigger: "blur", message: "请输入您的账号" }
        ],
        password: [
          { required: true, trigger: "blur", message: "请输入您的密码" }
        ],
        code: [{ required: true, trigger: "change", message: "请输入验证码" }]
      },
      loading: false,
      // 验证码开关
      captchaEnabled: true,
      // 注册开关
      register: false,
      redirect: undefined
    };
  },
  watch: {
    $route: {
      handler: function(route) {
        this.redirect = route.query && route.query.redirect;
      },
      immediate: true
    }
  },
  created() {
    this.getCode();
    this.getCookie();
  },
  methods: {
    getCode() {
        // this.codeUrl = "data:image/gif;base64,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";
        // this.loginForm.uuid = "b58d1b8e00764f3d862601ab9f2a0716";
        // this.captchaEnabled=true;
        // return;
       getCodeImg().then(res => {
         this.captchaEnabled = res.captchaEnabled === undefined ? true : res.captchaEnabled;
         if (this.captchaEnabled) {
           this.codeUrl = "data:image/gif;base64," + res.data.imgData;
           this.loginForm.uuid = res.data.uuid;
         }
       });
    },
    getCookie() {
      const username = Cookies.get("username");
      const password = Cookies.get("password");
      const rememberMe = Cookies.get('rememberMe')
      this.loginForm = {
        username: username === undefined ? this.loginForm.username : username,
        password: password === undefined ? this.loginForm.password : decrypt(password),
        rememberMe: rememberMe === undefined ? false : Boolean(rememberMe)
      };
    },
    handleLogin() {
      this.$refs.loginForm.validate(valid => {
        if (valid) {
          this.loading = true;
          if (this.loginForm.rememberMe) {
            Cookies.set("username", this.loginForm.username, { expires: 30 });
            Cookies.set("password", encrypt(this.loginForm.password), { expires: 30 });
            Cookies.set('rememberMe', this.loginForm.rememberMe, { expires: 30 });
          } else {
            Cookies.remove("username");
            Cookies.remove("password");
            Cookies.remove('rememberMe');
          }

       //  this.$router.push({ path: this.redirect || "/" }).catch(()=>{});

          this.$store.dispatch("Login", this.loginForm).then(() => {
            this.$router.push({ path: this.redirect || "/" }).catch(()=>{});
          }).catch(() => {
            this.loading = false;
            if (this.captchaEnabled) {
              this.getCode();
            }
          });

        }
      });
    }
  }
};
</script>

<style rel="stylesheet/scss" lang="scss">
.login {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  background-image: url("../assets/images/login-background.jpg");
  background-size: cover;
}
.title {
  margin: 0px auto 30px auto;
  text-align: center;
  color: #707070;
}

.login-form {
  border-radius: 6px;
  background: #ffffff;
  width: 400px;
  padding: 25px 25px 5px 25px;
  .el-input {
    height: 38px;
    input {
      height: 38px;
    }
  }
  .input-icon {
    height: 39px;
    width: 14px;
    margin-left: 2px;
  }
}
.login-tip {
  font-size: 13px;
  text-align: center;
  color: #bfbfbf;
}
.login-code {
  width: 33%;
  height: 38px;
  float: right;
  img {
    cursor: pointer;
    vertical-align: middle;
  }
}
.el-login-footer {
  height: 40px;
  line-height: 40px;
  position: fixed;
  bottom: 0;
  width: 100%;
  text-align: center;
  color: #fff;
  font-family: Arial;
  font-size: 12px;
  letter-spacing: 1px;
}
.login-code-img {
  height: 38px;
}
</style>
